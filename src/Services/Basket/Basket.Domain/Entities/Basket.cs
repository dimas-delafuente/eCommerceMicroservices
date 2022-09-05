using Common.Primitives.Enumerations;
using Common.Primitives.ValueObjects;

namespace Basket.Domain.Entities;

public class Basket
{
    public Guid Id { get; private set; }

    private readonly List<BasketItem> _items;
    public IReadOnlyList<BasketItem> Items => _items.AsReadOnly();

    public Price? TotalPrice => _items.Count > 0 ? new Price(_items.Sum(i => i.Price.Amount), _items.FirstOrDefault()?.Price?.Currency ?? Currency.Euro) : new Price(0, Currency.Euro);

    public Basket(Guid id)
    {
        Id = id;
        _items = new List<BasketItem>();
    }

    public Basket(Guid id, List<BasketItem> items)
    {
        Id = id;
        _items = items;
    }

    public void AddItem(BasketItem item)
    {
        if (item is null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        _items.Add(item);
    }
}
