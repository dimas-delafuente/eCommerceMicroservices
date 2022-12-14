using EventBus.Core.Services;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace EventBus.Core;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEventBus(
        this IServiceCollection services,
        Action<EventBusSettings> settings)
    {
        var eventBusSettings = new EventBusSettings();
        settings.Invoke(eventBusSettings);

        services.AddMassTransit(config =>
        {
            foreach (var consumer in eventBusSettings.Consumers)
            {
                config.AddConsumer(consumer.Type);
            }

            config.UsingRabbitMq((ctx, opt) =>
            {
                opt.Host(eventBusSettings.Host);

                foreach (var consumer in eventBusSettings.Consumers)
                {
                    opt.ReceiveEndpoint(consumer.Queue, c =>
                    {
                        c.ConfigureConsumer(ctx, consumer.Type);
                    });
                }
            });
        });

        services.AddScoped<IEventBus, Services.EventBus>();

        return services;
    }
}
