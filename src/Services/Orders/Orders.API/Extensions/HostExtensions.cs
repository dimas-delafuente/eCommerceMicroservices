using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Orders.Infrastructure.Contexts;

namespace Orders.API.Extensions;

public static class HostExtensions
{
    public static IHost MigrateDatabase(this IHost host, int retry = 0)
    {
        var retryFor = retry;

        using var scope = host.Services.CreateScope();

        var services = scope.ServiceProvider;
        OrdersContext context = services.GetRequiredService<OrdersContext>();
        var logger = services.GetRequiredService<ILogger<OrdersContext>>();

        try
        {
            logger.LogInformation("Migrating database.");

            context.Database.Migrate();
            OrderContextSeed.SeedAsync(context).Wait();

            logger.LogInformation("Migrating completed.");
        }
        catch (SqlException ex)
        {
            logger.LogError(ex, "An error occurred while migrating database.");

            if (retryFor < 50)
            {
                retryFor++;
                Thread.Sleep(2000);
                MigrateDatabase(host, retryFor);
            }
        }

        return host;
    }
}
