using Catalog.Domain.Abstractions.Repositories;
using Discount.Grpc.Protos;
using ProductDiscount = Catalog.Domain.Entities.ProductDiscount;

namespace Catalog.Infrastructure.Repositories;

internal class ProductDiscountRepository : IProductDiscountRepository
{
    private readonly ProductDiscountProtoService.ProductDiscountProtoServiceClient _productDiscountService;

    public ProductDiscountRepository(ProductDiscountProtoService.ProductDiscountProtoServiceClient productDiscountService)
    {
        _productDiscountService = productDiscountService;
    }

    public async Task<IEnumerable<ProductDiscount>> GetAllAsync()
    {
        var request = new EmptyRequest() { };
        var response = await _productDiscountService.GetAllProductDiscountsAsync(request);

        return response?.ProductDiscounts != null ?
            response.ProductDiscounts.Select(x => FromProtoModel(x))
            : Enumerable.Empty<ProductDiscount>();
    }

    private static ProductDiscount FromProtoModel(Discount.Grpc.Protos.ProductDiscount productDiscount)
    {
        return ProductDiscount.Create(
            Guid.Parse(productDiscount.ProductId),
            productDiscount.Description,
            Convert.ToDecimal(productDiscount.Amount));
    }

    public async Task<ProductDiscount?> GetByProductIdAsync(Guid productId)
    {
        var productDiscount = await _productDiscountService.GetProductDiscountAsync(new GetProductDiscountRequest
        {
            ProductId = productId.ToString()
        });

        return productDiscount != null ?
            ProductDiscount.Create(Guid.Parse(productDiscount.ProductId), productDiscount.Description, Convert.ToDecimal(productDiscount.Amount))
            : null;
    }
}
