using Catalog.Domain.Abstractions.Repositories;
using Catalog.Infrastructure.Connection;
using Catalog.Infrastructure.Contexts;
using Catalog.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration dbSettings)
        {
            services
                .AddOptions<CatalogDatabaseSettings>()
                .Bind(dbSettings);
            MongoEntityMapsRegistrator.RegisterDocumentMaps();

            services.AddSingleton<ICatalogContext, CatalogContext>();
            services.AddScoped<IProductsRepository, ProductsRepository>();

            return services;
        }
    }
}
