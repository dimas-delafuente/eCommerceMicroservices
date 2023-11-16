using Basket.Domain.Abstractions.Repositories;
using Common.Tracing;
using Discount.Grpc.Protos;
using ProductDiscount = Basket.Domain.Entities.ProductDiscount;

namespace Basket.Infrastructure.Repositories;

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

        using var activity = GenericActivity.Instance.StartActivity("GetAllDiscounts");

        var response = await _productDiscountService.GetAllProductDiscountsAsync(request);

        activity?.Stop();

        return response?.ProductDiscounts != null ?
            response.ProductDiscounts.Select(x => FromProtoModel(x))
            : Enumerable.Empty<ProductDiscount>();
    }

    public async Task<ProductDiscount?> GetByProductIdAsync(Guid productId)
    {
        using var activity = GenericActivity.Instance.StartActivity("GetDiscount");

        var productDiscount = await _productDiscountService.GetProductDiscountAsync(new GetProductDiscountRequest
        {
            ProductId = productId.ToString()
        });

        activity?.Stop();


        return productDiscount != null ?
            ProductDiscount.Create(Guid.Parse(productDiscount.ProductId), productDiscount.Description, Convert.ToDecimal(productDiscount.Amount))
            : null;
    }

    private static ProductDiscount FromProtoModel(Discount.Grpc.Protos.ProductDiscount productDiscount)
    {
        return ProductDiscount.Create(
            Guid.Parse(productDiscount.ProductId),
            productDiscount.Description,
            Convert.ToDecimal(productDiscount.Amount));
    }
}
