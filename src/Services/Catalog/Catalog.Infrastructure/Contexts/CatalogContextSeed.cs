using Catalog.Domain.Entities;
using Catalog.Domain.Enumerations;
using Catalog.Domain.ValueObjects;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Contexts;

internal class CatalogContextSeed
{
    public static void SeedData(IMongoCollection<Product> productsCollection)
    {
        if (!productsCollection.Find(p => true).Any())
        {
            productsCollection.InsertMany(GetProducts());
        }
    }

    private static IEnumerable<Product> GetProducts()
    {
        yield return Product.Create(
            "IPhone X",
            "Smart Phone",
            "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
            "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
            "product-1.png",
            new Price(950.00M, Currency.Euro)
            );

        yield return Product.Create(
            "Samsung 10",
            "Smart Phone",
            "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
            "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
            "product-2.png",
            new Price(840.00M, Currency.Euro)
            );

        yield return Product.Create(
            "Huawei Plus",
            "Smart Phone",
            "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
            "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
            "product-3.png",
            new Price(650.00M, Currency.Euro)
            );

        yield return Product.Create(
            "Xiaomi Mi 9",
            "White Appliances",
            "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
            "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
            "product-4.png",
            new Price(470.00M, Currency.Euro)
            );

        yield return Product.Create(
            "HTC U11+ Plus",
            "Smart Phone",
            "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
            "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
            "product-5.png",
            new Price(380.00M, Currency.Euro)
            );

        yield return Product.Create(
            "LG G7 ThinQ",
            "Home Kitchen",
            "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
            "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
            "product-5.png",
            new Price(240.00M, Currency.Euro)
            );
    }
}
