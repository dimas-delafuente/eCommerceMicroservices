using Common.Primitives;
using Common.Primitives.Domain;

namespace Basket.Domain.Entities;

public class ProductDiscount : Entity<Guid>
{
    public string Description { get; private set; }
    public decimal Amount { get; private set; }

    public ProductDiscount(Guid id, string description, decimal amount) : base(id)
    {
        Description = description;

        Ensure.That<ArgumentException>(amount > 0, "Amount must be positive.");
        Amount = amount;
    }

    public static ProductDiscount Create(Guid productId, string description, decimal amount)
        => new ProductDiscount(productId, description, amount);
}
