using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Orders.Application.Services;
using Orders.Domain.Abstractions.Repositories;
using Orders.Infrastructure.Contexts;
using Orders.Infrastructure.Interceptors;
using Orders.Infrastructure.Mail;
using Orders.Infrastructure.Repositories;

namespace Orders.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddSingleton<AuditEntityInterceptor>();
        services.AddSingleton<DomainEventToOutboxMessageInterceptor>();

        services.AddDbContext<OrdersContext>(
            (sp, optionsBuilder) =>
        {
            var autidableInterceptor = sp.GetService<AuditEntityInterceptor>()!;
            var outboxMessagesInterceptor = sp.GetService<DomainEventToOutboxMessageInterceptor>()!;

            optionsBuilder.UseSqlServer(configuration.GetSection("DatabaseSettings")["ConnectionString"])
                .AddInterceptors(autidableInterceptor)
                .AddInterceptors(outboxMessagesInterceptor);
        });

        //services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
        services.AddScoped<IOrderRepository, OrderRepository>();

        services.Configure<EmailSettings>(options => configuration.GetSection("EmailSettings"));
        services.AddSingleton<IEmailService, EmailService>();

        return services;
    }
}
