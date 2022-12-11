using ErrorOr;

namespace Basket.Domain.Errors;

public static partial class Errors
{
    public static class ProductDiscount
    {
        public static Error Empty => Error.Validation(code: "ProductDiscount.Empty", "Product discount must be greater than zero");
        public static Error ExceedsPrice => Error.Validation(code: "ProductDiscount.ExceedsPrice", "Product discount exceeds product price");
    }
}
