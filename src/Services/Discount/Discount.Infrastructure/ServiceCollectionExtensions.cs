﻿using Discount.Domain.Abstractions.Repositories;
using Discount.Infrastructure.Connection;
using Discount.Infrastructure.Contexts;
using Discount.Infrastructure.DbUp;
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

        services.AddSingleton<IDiscountContext, DiscountContext>();
        services.AddScoped<IProductDiscountRepository, ProductDiscountRepository>();

        DatabaseMigration.Migrate(dbSettings["ConnectionString"]);
        return services;
    }
}
