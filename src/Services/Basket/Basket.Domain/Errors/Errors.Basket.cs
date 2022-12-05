using ErrorOr;

namespace Basket.Domain.Errors;

public static partial class Errors
{
    public static class Basket
    {
        public static Error NotFound => Error.NotFound(code: "Basket.NotFound", "Unable to find basket");
        public static Error Empty => Error.NotFound(code: "Basket.Empty", "Basket is empty");

    }
}

