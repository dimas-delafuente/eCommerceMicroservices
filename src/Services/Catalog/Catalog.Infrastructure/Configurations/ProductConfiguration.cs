using Catalog.Domain.Entities;
using MongoDB.Bson.Serialization;

namespace Catalog.Infrastructure.Configurations;

internal sealed class ProductConfiguration : EntityDbConfiguration<Product>
{
    public override void Map(BsonClassMap<Product> cm)
    {
        cm.AutoMap();
    }
}
