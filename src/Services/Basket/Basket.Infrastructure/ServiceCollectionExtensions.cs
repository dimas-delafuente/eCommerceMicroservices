using Basket.Domain.Abstractions.Repositories;
using Basket.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Basket.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration redisConfiguration)
    {
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = redisConfiguration["ConnectionString"];
        });

        services.AddScoped<IBasketRepository, BasketRepository>();
        return services;
    }
}
