using Catalog.Domain.Shared;
using Catalog.Infrastructure.Contexts;

namespace Catalog.Infrastructure.Repositories;

internal abstract class RepositoryBase
{
    protected readonly ICatalogContext _catalogContext;

    public RepositoryBase(ICatalogContext catalogContext)
    {
        Ensure.NotNull(catalogContext, nameof(catalogContext));
        _catalogContext = catalogContext;
    }
}
