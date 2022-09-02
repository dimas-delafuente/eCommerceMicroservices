namespace Catalog.Infrastructure.Connection;

public class CatalogDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string ProductsCollection { get; set; } = null!;
}
