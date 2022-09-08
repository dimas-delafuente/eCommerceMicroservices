using System.Text.Json.Serialization;

namespace Basket.Domain.Entities;

public class Basket
{
    public Guid Id { get; set; }

    public IReadOnlyList<BasketItem> Items { get; set; }

    public decimal TotalPrice => Items.Sum(i => i.Price);

    public Basket()
    {

    }

    public Basket(Guid id)
    {
        Id = id;
        Items = new List<BasketItem>();
    }

    public Basket(Guid id, List<BasketItem> items)
    {
        Id = id;
        Items = items;
    }
}
