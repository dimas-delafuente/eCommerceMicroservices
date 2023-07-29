using Common.Primitives.ValueObjects;

namespace Shopping.Aggregator.Models;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; private set; } = null!;
    public string? Category { get; private set; }
    public string? Summary { get; private set; }
    public string? Description { get; private set; }
    public string? ImageFile { get; private set; }
    public Price Price { get; private set; } = null!;
}
