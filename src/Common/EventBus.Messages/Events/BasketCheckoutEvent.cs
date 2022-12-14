namespace EventBus.Messages.Events;

public sealed record BasketCheckoutEvent(
    string UserName,
    decimal TotalPrice,
    string FirstName,
    string LastName,
    string EmailAddress,
    string AddressLine,
    string Country,
    string State,
    string ZipCode,
    string CardName,
    string CardNumber,
    string Expiration,
    string Ccv,
    int PaymentMethod) : IntegrationBaseEvent, IIntegrationEvent;