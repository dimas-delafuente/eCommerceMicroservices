using Catalog.Domain.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Contexts;

internal interface ICatalogContext
{
    IMongoCollection<Product> Products { get; }
}
