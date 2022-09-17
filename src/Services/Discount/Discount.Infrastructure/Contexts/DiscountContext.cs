using System.Data;
using Discount.Infrastructure.Connection;
using Microsoft.Extensions.Options;
using Npgsql;

namespace Discount.Infrastructure.Contexts;

internal class DiscountContext : IDiscountContext
{
    private readonly string _connectionString;

    public DiscountContext(IOptions<DiscountDatabaseSettings> databaseSettings)
    {
        _connectionString = databaseSettings.Value.ConnectionString;
    }

    public IDbConnection CreateConnection()
        => new NpgsqlConnection(_connectionString);
}
