using ErrorOr;

namespace Discount.Domain.Errors;

public static partial class Errors
{
    public static class ProductDiscount
    {
        public static Error NotFound => Error.NotFound(code: "ProductDiscount.NotFound", "Unable to find product discount");
    }
}
