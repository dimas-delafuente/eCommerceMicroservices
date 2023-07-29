namespace Shopping.Aggregator.Models;

public class BillingAddress
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string EmailAddress { get; private set; }
    public string AddressLine { get; private set; }
    public string Country { get; private set; }
    public string State { get; private set; }
    public string ZipCode { get; private set; }
}