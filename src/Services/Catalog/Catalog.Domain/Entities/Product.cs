using Common.Primitives.Domain;
using Common.Primitives.ValueObjects;

namespace Catalog.Domain.Entities;

public class Product : AggregateRoot<Guid>
{
    public string Name { get; private set; }
    public string Category { get; private set; }
    public string Summary { get; private set; }
    public string Description { get; private set; }
    public string ImageFile { get; private set; }
    public Price Price { get; private set; }

    public Product(Guid id, string name, string category, string summary, string description, string imageFile, Price price) : base(id)
    {
        Name = name;
        Category = category;
        Summary = summary;
        Description = description;
        ImageFile = imageFile;
        Price = price;
    }

    public static Product Create(Guid id, string name, string category, string summary, string description, string imageFile, Price price)
    {
        return new Product(id, name, category, summary, description, imageFile, price);
    }

    public static Product Create(string name, string category, string summary, string description, string imageFile, Price price)
    {
        return new Product(Guid.NewGuid(), name, category, summary, description, imageFile, price);
    }
}
