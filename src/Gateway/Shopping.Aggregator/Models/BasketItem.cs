using Common.Primitives.ValueObjects;

namespace Shopping.Aggregator.Models;

public class BasketItem
{
    public int Quantity { get; set; }
    public Price Price { get; set; }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = null!;

    //Product Related Additional Fields
    public string? Category { get; set; }
    public string? Summary { get; set; }
    public string? Description { get; set; }
    public string? ImageFile { get; set; }
}