using EventBus.Messages.Events;

namespace Basket.Application.Contracts;

public sealed record CheckoutBasketCommand(
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
    int PaymentMethod);

public static class CheckoutBasketCommandExtensions
{

    public static BasketCheckoutEvent ToIntegrationEvent(this CheckoutBasketCommand command)
    {
        return new BasketCheckoutEvent(command.UserName,
                                       command.TotalPrice,
                                       command.FirstName,
                                       command.LastName,
                                       command.EmailAddress,
                                       command.AddressLine,
                                       command.Country,
                                       command.State,
                                       command.ZipCode,
                                       command.CardName,
                                       command.CardNumber,
                                       command.Expiration,
                                       command.Ccv,
                                       command.PaymentMethod);
    }
}