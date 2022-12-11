using Common.Primitives;
using Common.Primitives.ValueObjects;

namespace Orders.Domain.ValueObjects;

public sealed class BillingAddress : ValueObject
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string EmailAddress { get; private set; }
    public string AddressLine { get; private set; }
    public string Country { get; private set; }
    public string State { get; private set; }
    public string ZipCode { get; private set; }

    private BillingAddress(string firstName, string lastName, string emailAddress, string addressLine, string country, string state, string zipCode)
    {
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAddress;
        AddressLine = addressLine;
        Country = country;
        State = state;
        ZipCode = zipCode;
    }

    public static BillingAddress From (string firstName, string lastName, string emailAddress, string addressLine, string country, string state, string zipCode)
    {
        Ensure.Argument.NotNullOrEmpty(firstName, nameof(firstName));
        Ensure.Argument.NotNullOrEmpty(lastName, nameof(lastName));
        Ensure.Argument.NotNullOrEmpty(emailAddress, nameof(emailAddress));
        Ensure.Argument.NotNullOrEmpty(addressLine, nameof(addressLine));
        Ensure.Argument.NotNullOrEmpty(country, nameof(country));
        Ensure.Argument.NotNullOrEmpty(state, nameof(state));
        Ensure.Argument.NotNullOrEmpty(zipCode, nameof(zipCode));

        return new BillingAddress(firstName, lastName, emailAddress, addressLine, country, state, zipCode);
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return FirstName;
        yield return LastName;
        yield return EmailAddress;
        yield return AddressLine;
        yield return Country;
        yield return State;
        yield return ZipCode;
    }
}
