using EventBus.Core;
using EventBus.Messages.Common;
using Orders.API.EventBusConsumers;
using Orders.Infrastructure.BackgroundJobs;
using Quartz;

namespace Orders.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBackgroundJobs(this IServiceCollection services)
    {
        services.AddQuartz(configure =>
        {
            var jobKey = new JobKey(nameof(ProcessOutboxMessageJob));
            configure
                .AddJob<ProcessOutboxMessageJob>(jobKey)
                .AddTrigger(
                    trigger => trigger
                        .ForJob(jobKey)
                        .WithSimpleSchedule(schedule =>
                            schedule.WithIntervalInSeconds(10)
                                    .RepeatForever()));

            configure.UseMicrosoftDependencyInjectionJobFactory();
        });

        services.AddQuartzHostedService();

        return services;
    }

    public static IServiceCollection RegisterEventBus(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEventBus(opt =>
        {
            opt.Host = configuration.GetSection("EventBusSettings")["HostAddress"];
            opt.Consumers = new List<EventBusConsumerSettings>
            {
                EventBusConsumerSettings.From(EventBusQueues.BasketCheckoutQueue, typeof(BasketCheckoutConsumer))
            };
        });

        services.AddScoped<BasketCheckoutConsumer>();

        return services;
    }
}
