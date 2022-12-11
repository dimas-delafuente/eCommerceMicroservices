using Common.Primitives.Enumerations;

namespace Common.Primitives.ValueObjects;

public class Price : ValueObject
{
    public decimal Amount { get; private set; }
    public Currency Currency { get; private set; }

    private Price()
    {

    }

    public Price(decimal amount, Currency currency)
    {
        Ensure.Argument.NotNull(currency, nameof(currency));
        Ensure.Argument.IsNot(amount < 0, $"Amount must be positive.");

        Amount = amount;
        Currency = currency;
    }

    public static Price From(decimal amount, string code)
    {
        Ensure.Argument.NotNull(code, nameof(code));

        return new Price(amount, Enumeration.FromDisplayName<Currency>(code));
    }

    public static Price From(decimal amount, Currency currency)
    {
        return new Price(amount, currency);
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Amount;
        yield return Currency;
    }
}

