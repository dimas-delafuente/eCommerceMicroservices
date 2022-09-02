using ErrorOr;

namespace Catalog.Domain.Shared.Errors;

public static partial class Errors
{
    public static class Product
    {
        public static Error NotFound => Error.NotFound(code: "Products.NotFound", "Unable to find product");
    }
}
