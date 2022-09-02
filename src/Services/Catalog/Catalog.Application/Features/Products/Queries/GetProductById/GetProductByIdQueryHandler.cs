using Catalog.Application.Abstractions.Queries;
using Catalog.Domain.Abstractions.Repositories;
using Catalog.Domain.Shared;
using Catalog.Domain.Shared.Errors;
using ErrorOr;

namespace Catalog.Application.Features.Products.Queries.GetProductById;

internal class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, ErrorOr<GetProductByIdQueryResult>>
{
    private readonly IProductsRepository _productsRepository;

    public GetProductByIdQueryHandler(IProductsRepository productsRepository)
    {
        Ensure.NotNull(productsRepository, nameof(productsRepository));
        _productsRepository = productsRepository;
    }

    public async Task<ErrorOr<GetProductByIdQueryResult>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _productsRepository.GetByIdAsync(request.ProductId);

        if (product is null)
        {
            return Errors.Product.NotFound;
        }

        return new GetProductByIdQueryResult(product);
    }
}
