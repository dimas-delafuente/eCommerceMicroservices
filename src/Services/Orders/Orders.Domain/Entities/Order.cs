using Common.Primitives;
using Common.Primitives.Domain;
using Common.Primitives.ValueObjects;
using Orders.Domain.Events;
using Orders.Domain.ValueObjects;

namespace Orders.Domain.Entities;

public class Order : AggregateRoot<Guid>, IAuditableEntity
{
    private Order()
    {

    }

    private Order(
        Guid id,
        string userName,
        Price totalPrice,
        BillingAddress billingAddress,
        PaymentDetails paymentDetails) : base(id)
    {
        UserName = userName;
        TotalPrice = totalPrice;
        BillingAddress = billingAddress;
        PaymentDetails = paymentDetails;
    }

    public string UserName { get; private set; }
    public Price TotalPrice { get; private set; }

    public BillingAddress BillingAddress { get; private set; }

    public PaymentDetails PaymentDetails { get; private set; }

    public DateTime CreatedOnUtc { get; private set; }
    public DateTime? ModifiedOnUtc { get; private set; }

    public static Order Create(string userName, Price totalPrice, BillingAddress billingAddress, PaymentDetails paymentDetails)
    {
        return new Order(Guid.NewGuid(), userName, totalPrice, billingAddress, paymentDetails);
    }

    public void Checkout()
    {
        RaiseDomainEvent(new OrderCheckoutDomainEvent(Id));
    }

    public void UpdateBillingAddress(BillingAddress billingAddress)
    {
        Ensure.Argument.NotNull(billingAddress, nameof(billingAddress));
        BillingAddress = billingAddress;

        RaiseDomainEvent(new OrderBillingAddressUpdatedDomainEvent(Id));
    }
}
