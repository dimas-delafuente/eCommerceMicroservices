using Common.Primitives;
using Common.Primitives.ValueObjects;

namespace Orders.Domain.ValueObjects;

public sealed class PaymentDetails : ValueObject
{
    public string CardName { get; private set; }
    public string CardNumber { get; private set; }
    public string Expiration { get; private set; }
    public string CVV { get; private set; }
    public int PaymentMethod { get; private set; }

    private PaymentDetails(string cardName, string cardNumber, string expiration, string CVV, int paymentMethod)
    {
        CardName = cardName;
        CardNumber = cardNumber;
        Expiration = expiration;
        this.CVV = CVV;
        PaymentMethod = paymentMethod;
    }

    public static PaymentDetails From(string cardName, string cardNumber, string expiration, string CVV, int paymentMethod)
    {
        Ensure.Argument.NotNullOrEmpty(cardName, nameof(cardName));
        Ensure.Argument.NotNullOrEmpty(cardNumber, nameof(cardNumber));
        Ensure.Argument.NotNullOrEmpty(expiration, nameof(expiration));
        Ensure.Argument.NotNullOrEmpty(CVV, nameof(CVV));
        Ensure.Argument.IsNot(paymentMethod < 0, nameof(paymentMethod));

        return new PaymentDetails(cardName, cardNumber, expiration, CVV, paymentMethod);
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return CardName;
        yield return CardNumber;
        yield return Expiration;
        yield return CVV;
        yield return PaymentMethod;
    }
}
