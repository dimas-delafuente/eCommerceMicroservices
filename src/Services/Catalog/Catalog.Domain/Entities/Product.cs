using Catalog.Domain.Shared;
using Catalog.Domain.ValueObjects;

namespace Catalog.Domain.Entities;

public class Product : Entity
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
}
