using Discount.Domain.Abstractions.Repositories;
using Discount.Infrastructure.Connection;
using Discount.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Discount.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration dbSettings)
    {
        services
            .AddOptions<DiscountDatabaseSettings>()
            .Bind(dbSettings);

        services.AddScoped<IProductDiscountRepository, ProductDiscountRepository>();
        return services;
    }
}
