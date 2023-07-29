namespace Shopping.Aggregator.Models;

public class PaymentDetails
{
    public string CardName { get; private set; }
    public string CardNumber { get; private set; }
    public string Expiration { get; private set; }
    public string CVV { get; private set; }
    public int PaymentMethod { get; private set; }
}