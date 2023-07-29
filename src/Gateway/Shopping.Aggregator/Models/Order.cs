using Common.Primitives.ValueObjects;

namespace Shopping.Aggregator.Models;

public class Order
{
    public Guid Id { get; set; }
    public string UserName { get; private set; }
    public Price TotalPrice { get; private set; }

    public BillingAddress BillingAddress { get; private set; }

    public PaymentDetails PaymentDetails { get; private set; }
}
