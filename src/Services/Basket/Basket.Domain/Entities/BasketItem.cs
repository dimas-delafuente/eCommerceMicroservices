using Common.Primitives.ValueObjects;

namespace Basket.Domain.Entities;

public class BasketItem
{
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }
    public Price Price { get; private set; }

    public BasketItem(Guid productId, int quantity, Price price)
    {
        ProductId = productId;
        Quantity = quantity;
        Price = price;
    }
}