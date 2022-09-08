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
}