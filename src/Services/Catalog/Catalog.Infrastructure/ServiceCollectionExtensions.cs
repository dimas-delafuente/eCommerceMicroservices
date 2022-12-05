using Catalog.Domain.Abstractions.Repositories;
using Catalog.Infrastructure.Connection;
using Catalog.Infrastructure.Contexts;
using Catalog.Infrastructure.Repositories;
using Discount.Grpc.Protos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration dbSettings,
            IConfiguration discountGrpcSettings)
        {
            services
                .AddOptions<CatalogDatabaseSettings>()
                .Bind(dbSettings);
            MongoEntityMapsRegistrator.RegisterDocumentMaps();

            services.AddGrpcClient<ProductDiscountProtoService.ProductDiscountProtoServiceClient>(opt =>
            {
                opt.Address = new Uri(discountGrpcSettings["DiscountUrl"]);
            });

            services.AddSingleton<ICatalogContext, CatalogContext>();
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IProductDiscountRepository, ProductDiscountRepository>();

            return services;
        }
    }
}
