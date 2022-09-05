using Basket.Application.Abstractions;
using Basket.Application.Managers;
using Microsoft.Extensions.DependencyInjection;

namespace Basket.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IBasketManager, BasketManager>();
        return services;
    }
}
