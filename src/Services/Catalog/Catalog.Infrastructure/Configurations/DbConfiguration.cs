using MongoDB.Bson.Serialization;

namespace Catalog.Infrastructure.Configurations;

internal abstract class EntityDbConfiguration<T>
{
    protected EntityDbConfiguration()
    {
        if (!BsonClassMap.IsClassMapRegistered(typeof(T)))
        {
            BsonClassMap.RegisterClassMap<T>(Map);
        }
    }

    public abstract void Map(BsonClassMap<T> cm);
}
