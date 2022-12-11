using Common.Primitives.Enumerations;
using Common.Primitives.ValueObjects;
using Orders.Domain.Entities;
using Orders.Domain.ValueObjects;

namespace Orders.Infrastructure.Contexts;

public static class OrderContextSeed
{
    public static async Task SeedAsync(OrdersContext orderContext)
    {
        if (!orderContext.Orders.Any())
        {
            orderContext.Orders.AddRange(GetPreconfiguredOrders());
            _ = await orderContext.SaveChangesAsync();
        }
    }

    private static IEnumerable<Order> GetPreconfiguredOrders()
    {
        return new List<Order>
            {
                Order.Create(
                    "devlafuente",
                    Price.From(350, Currency.Euro),
                    BillingAddress.From("Dimas", "de la Fuente", "devlafuente@gmail.com", "Bootellos", "Spain", "Madrid", "28231"),
                    PaymentDetails.From("Dimas de la Fuente", "0000-0000-0000-0000", "07/29", "000", 1))
            };
    }
}
