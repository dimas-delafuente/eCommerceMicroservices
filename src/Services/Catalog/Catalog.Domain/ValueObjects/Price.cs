using Catalog.Domain.Enumerations;
using Catalog.Domain.Shared;

namespace Catalog.Domain.ValueObjects;

public class Price : ValueObject
{
    public decimal Amount { get; }
    public Currency Currency { get; }

    public Price(decimal amount, Currency currency)
    {
        Ensure.Argument.NotNull(currency, nameof(currency));
        Amount = amount;
        Currency = currency;
    }

    public static Price From(decimal amount, string code)
    {
        return new Price(amount, Enumeration.FromDisplayName<Currency>(code));
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Amount;
        yield return Currency;
    }
}

