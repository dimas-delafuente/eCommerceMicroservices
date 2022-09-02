using Catalog.Domain.Shared;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Catalog.Infrastructure.Configurations;

internal sealed class EntityConfiguration : EntityDbConfiguration<Entity>
{
    public override void Map(BsonClassMap<Entity> cm)
    {
        cm.AutoMap();
        cm.MapIdField(p => p.Id).SetIdGenerator(GuidGenerator.Instance);
    }
}
