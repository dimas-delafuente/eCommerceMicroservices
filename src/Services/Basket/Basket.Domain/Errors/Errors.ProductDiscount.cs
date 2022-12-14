using ErrorOr;

namespace Basket.Domain.Errors;

public static partial class Errors
{
    public static class ProductDiscount
    {
        public static Error Empty => Error.Validation(code: "ProductDiscount.Empty", "Product discount cannot be negative");
        public static Error ExceedsPrice => Error.Validation(code: "ProductDiscount.ExceedsPrice", "Product discount exceeds product price");
    }
}
