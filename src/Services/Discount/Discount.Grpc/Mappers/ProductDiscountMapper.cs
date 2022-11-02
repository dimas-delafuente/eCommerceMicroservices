using ProductDiscount = Discount.Grpc.Protos.ProductDiscount;

namespace Discount.Grpc.Mappers;

public static class ProductDiscountMapper
{
    public static ProductDiscount ToProtoModel(this Domain.Entities.ProductDiscount productDiscount)
        => new()
        {
            ProductId = productDiscount.ProductId.ToString(),
            Amount = Convert.ToDouble(productDiscount.Amount),
            Description = productDiscount.Description
        };
}
