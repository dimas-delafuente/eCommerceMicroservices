using ErrorOr;

namespace Basket.Domain.Errors;

public static class Errors
{
    public static class Basket
    {
        public static Error NotFound => Error.NotFound(code: "Basket.NotFound", "Unable to find basket");

    }
}

