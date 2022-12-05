using Common.Primitives.Domain;

namespace Catalog.Domain.Abstractions.Repositories;

public interface IRepository<T>
    where T : Entity<Guid>
{
}
