using Common.Primitives;

namespace Catalog.Domain.Abstractions.Repositories
{
    public interface IRepository<T>
        where T : Entity
    {
    }
}
