using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Idempotency;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddIdempotency(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IdempotencyContext>((sp, optionsBuilder) =>
        {
            optionsBuilder.UseSqlServer(configuration["ConnectionString"]);
        });

        services.AddScoped<IIdempotencyService, IdempotencyService>();
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(IdempotentCommandBehavior<,>));

        return services;
    }
}
