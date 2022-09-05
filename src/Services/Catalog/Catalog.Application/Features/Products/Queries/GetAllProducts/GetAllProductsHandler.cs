using Catalog.Application.Abstractions.Queries;
using Catalog.Domain.Abstractions.Repositories;
using Common.Primitives;
using ErrorOr;

namespace Catalog.Application.Features.Products.Queries.GetAllProducts;

internal class GetAllProductsQueryHandler : IQueryHandler<GetAllProductsQuery, ErrorOr<GetAllProductsQueryResult>>
{
    private readonly IProductsRepository _productsRepository;

    public GetAllProductsQueryHandler(IProductsRepository productsRepository)
    {
        Ensure.NotNull(productsRepository, nameof(productsRepository));
        _productsRepository = productsRepository;
    }

    public async Task<ErrorOr<GetAllProductsQueryResult>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productsRepository.GetAllAsync();
        return new GetAllProductsQueryResult(products);
    }
}
