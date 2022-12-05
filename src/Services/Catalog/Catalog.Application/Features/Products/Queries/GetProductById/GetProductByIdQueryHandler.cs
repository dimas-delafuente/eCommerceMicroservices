using Catalog.Domain.Abstractions.Repositories;
using Catalog.Domain.Shared.Errors;
using Common.Primitives;
using Common.Primitives.Queries;
using ErrorOr;

namespace Catalog.Application.Features.Products.Queries.GetProductById;

internal class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, ErrorOr<GetProductByIdQueryResult>>
{
    private readonly IProductsRepository _productsRepository;
    private readonly IProductDiscountRepository _productDiscountRepository;

    public GetProductByIdQueryHandler(IProductsRepository productsRepository, IProductDiscountRepository productDiscountRepository)
    {
        Ensure.NotNull(productsRepository, nameof(productsRepository));
        Ensure.NotNull(productDiscountRepository, nameof(productDiscountRepository));
        _productsRepository = productsRepository;
        _productDiscountRepository = productDiscountRepository;
    }

    public async Task<ErrorOr<GetProductByIdQueryResult>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _productsRepository.GetByIdAsync(request.ProductId);
        if (product is null)
        {
            return Errors.Product.NotFound;
        }

        var productDiscount = await _productDiscountRepository.GetByProductIdAsync(product.Id);
        if (productDiscount is not null)
        {
            product.SetDiscount(productDiscount);
        }

        return new GetProductByIdQueryResult(product);
    }
}
