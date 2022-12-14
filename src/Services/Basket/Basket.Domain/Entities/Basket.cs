namespace Basket.Domain.Entities;

public class Basket
{
    public Guid Id { get; set; }

    public IReadOnlyList<BasketItem> Items { get; set; } = new List<BasketItem>();

    public decimal TotalPrice => Items.Sum(i => i.Price);

    private Basket()
    {

    }

    public Basket(Guid id)
    {
        Id = id;
        Items = new List<BasketItem>();
    }

    public void SetItems(List<BasketItem> items)
    {
        Items = items;
    }
}
