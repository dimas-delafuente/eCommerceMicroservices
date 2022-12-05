using Basket.Domain.Abstractions.Repositories;
using Basket.Infrastructure.Repositories;
using Discount.Grpc.Protos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Basket.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration redisConfiguration,
        IConfiguration discountGrpcSettings)
    {
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = redisConfiguration["ConnectionString"];
        });

        services.AddGrpcClient<ProductDiscountProtoService.ProductDiscountProtoServiceClient>(opt =>
        {
            opt.Address = new Uri(discountGrpcSettings["DiscountUrl"]);
        });


        services.AddScoped<IBasketRepository, BasketRepository>();
        services.AddScoped<IProductDiscountRepository, ProductDiscountRepository>();

        return services;
    }
}
