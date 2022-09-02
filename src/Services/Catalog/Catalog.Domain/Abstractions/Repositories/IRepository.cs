using Catalog.Domain.Shared;

namespace Catalog.Domain.Abstractions.Repositories
{
    public interface IRepository<T>
        where T : Entity
    {
    }
}
