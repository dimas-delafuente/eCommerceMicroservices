using Catalog.Domain.Entities;
using Catalog.Infrastructure.Connection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Contexts;

internal sealed class CatalogContext: ICatalogContext
{
    private readonly IMongoClient _client;
    private readonly IMongoDatabase _database;

    private readonly CatalogDatabaseSettings _settings;

    public IMongoCollection<Product> Products => _database.GetCollection<Product>(_settings.ProductsCollection);

    public CatalogContext(IOptions<CatalogDatabaseSettings> conn)
    {
        _settings = conn.Value;

        var url = new MongoUrl(_settings.ConnectionString);
        _client = new MongoClient(url.Url);
        _database = _client.GetDatabase(_settings.DatabaseName);
        CatalogContextSeed.SeedData(Products);
    }
}
