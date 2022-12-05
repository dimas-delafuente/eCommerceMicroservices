using Catalog.Domain.Abstractions.Repositories;
using Common.Primitives;
using Common.Primitives.Queries;
using ErrorOr;

namespace Catalog.Application.Features.Products.Queries.GetAllProducts;

internal class GetAllProductsQueryHandler : IQueryHandler<GetAllProductsQuery, ErrorOr<GetAllProductsQueryResult>>
{
    private readonly IProductsRepository _productsRepository;
    private readonly IProductDiscountRepository _productDiscountRepository;

    public GetAllProductsQueryHandler(IProductsRepository productsRepository, IProductDiscountRepository productDiscountRepository)
    {
        Ensure.NotNull(productsRepository, nameof(productsRepository));
        Ensure.NotNull(productDiscountRepository, nameof(productDiscountRepository));
        _productsRepository = productsRepository;
        _productDiscountRepository = productDiscountRepository;
    }

    public async Task<ErrorOr<GetAllProductsQueryResult>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = (await _productsRepository.GetAllAsync()).ToDictionary(k => k.Id, v => v);

        if (products.Any())
        {
            var productDiscounts = await _productDiscountRepository.GetAllAsync();
            foreach (var productDiscount in productDiscounts)
            {
                if (products.TryGetValue(productDiscount.Id, out var product))
                {
                    product.SetDiscount(productDiscount);
                }
            }
        }

        return new GetAllProductsQueryResult(products.Values);
    }
}
