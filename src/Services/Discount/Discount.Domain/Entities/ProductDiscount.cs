using Common.Primitives.Domain;

namespace Discount.Domain.Entities;

public class ProductDiscount : Entity<int>
{
    public Guid ProductId { get; private set; }
    public string Description { get; private set; }
    public decimal Amount { get; private set; }

    private ProductDiscount(int id, Guid productId, string description, decimal amount)
        : base(id)
    {
        ProductId = productId;
        Description = description;
        Amount = amount;
    }

    public static ProductDiscount Create(Guid productId, string description, decimal amount)
    {
        return new ProductDiscount(0, productId, description, amount);
    }

    public static ProductDiscount Create(int id, Guid productId, string description, decimal amount)
    {
        return new ProductDiscount(id, productId, description, amount);
    }
}
