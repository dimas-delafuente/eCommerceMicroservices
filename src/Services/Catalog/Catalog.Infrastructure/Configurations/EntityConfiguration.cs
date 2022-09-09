using Common.Primitives.Domain;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Catalog.Infrastructure.Configurations;

internal sealed class EntityConfiguration : EntityDbConfiguration<Entity<Guid>>
{
    public override void Map(BsonClassMap<Entity<Guid>> cm)
    {
        cm.AutoMap();
        cm.MapIdField(p => p.Id).SetIdGenerator(GuidGenerator.Instance);
    }
}
