﻿namespace Common.Primitives.Enumerations;

public sealed class Currency : Enumeration
{
    private static readonly IDictionary<int, Currency> _currencies =
        new Dictionary<int, Currency>();

    public static readonly Currency Euro = new(1, "EUR");

    private Currency() : base(Euro.Id, Euro.Name)
    {

    }

    public Currency(int id, string code) : base(id, code)
    {
        Ensure.Positive(id, nameof(id));
        Ensure.Argument.NotNullOrEmpty(code, nameof(code));
        _currencies.Add(id, this);
    }

    public static IReadOnlyCollection<Currency> Values => _currencies.Values as IReadOnlyCollection<Currency>;
}
