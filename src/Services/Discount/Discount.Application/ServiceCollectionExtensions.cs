using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Discount.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining(typeof(ServiceCollectionExtensions));
        });
        
        return services;
    }
}
