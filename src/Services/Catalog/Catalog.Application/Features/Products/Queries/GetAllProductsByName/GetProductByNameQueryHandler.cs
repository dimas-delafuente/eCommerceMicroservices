using Catalog.Application.Abstractions.Queries;
using Catalog.Domain.Abstractions.Repositories;
using Common.Primitives;
using ErrorOr;

namespace Catalog.Application.Features.Products.Queries.GetAllProductsByName;

internal class GetProductByNameQueryHandler : IQueryHandler<GetAllProductsByNameQuery, ErrorOr<GetAllProductsByNameQueryResult>>
{
    private readonly IProductsRepository _productsRepository;

    public GetProductByNameQueryHandler(IProductsRepository productsRepository)
    {
        Ensure.NotNull(productsRepository, nameof(productsRepository));
        _productsRepository = productsRepository;
    }

    public async Task<ErrorOr<GetAllProductsByNameQueryResult>> Handle(GetAllProductsByNameQuery request, CancellationToken cancellationToken)
    {
        var products = await _productsRepository.GetAllByProductNameAsync(request.Name);
        return new GetAllProductsByNameQueryResult(products);
    }
}
