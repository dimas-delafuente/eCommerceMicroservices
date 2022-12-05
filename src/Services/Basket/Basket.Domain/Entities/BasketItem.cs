using Common.Primitives;

namespace Basket.Domain.Entities;

public class BasketItem
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public BasketItem()
    {

    }

    public BasketItem(Guid productId, int quantity, decimal price)
    {
        ProductId = productId;
        Quantity = quantity;
        Price = price;
    }

    public void ApplyDiscount(decimal discount)
    {
        Ensure.That(discount > 0, Errors.Errors.ProductDiscount.Empty.Description);
        Ensure.That(discount > Price, Errors.Errors.ProductDiscount.ExceedsPrice.Description);
        Price -= discount;
    }
}