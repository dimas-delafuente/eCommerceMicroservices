using Catalog.Infrastructure.Contexts;
using Common.Primitives;

namespace Catalog.Infrastructure.Repositories;

internal abstract class DatabaseRepositoryBase
{
    protected readonly ICatalogContext _catalogContext;

    public DatabaseRepositoryBase(ICatalogContext catalogContext)
    {
        Ensure.NotNull(catalogContext, nameof(catalogContext));
        _catalogContext = catalogContext;
    }
}
