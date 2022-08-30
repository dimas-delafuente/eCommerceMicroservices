using Catalog.Domain.Entities;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Catalog.Infrastructure.Configurations
{
    internal sealed class ProductConfiguration : IDbConfiguration<Product>
    {
        public void Register()
        {
            BsonClassMap.RegisterClassMap<Product>(cm => {
                cm.AutoMap();
                cm.MapIdField("id").SetIdGenerator(GuidGenerator.Instance);
            });
        }
    }
}
