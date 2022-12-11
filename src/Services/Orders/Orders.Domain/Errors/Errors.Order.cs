using ErrorOr;

namespace Orders.Domain.Errors;

public static partial class Errors
{
    public static class Order
    {
        public static Error CheckoutError => Error.Failure(code: "Orders.CheckoutError", "An error ocurring while checking out the order");
        public static Error NotFound => Error.NotFound(code: "Orders.NotFound", "Order not found");
    }
}
