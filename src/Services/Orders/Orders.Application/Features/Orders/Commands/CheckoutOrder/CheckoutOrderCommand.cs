using Common.Primitives.Commands;
using ErrorOr;

namespace Orders.Application.Features.Orders.Commands.CheckoutOrder;

public sealed record CheckoutOrderCommand(
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
    int PaymentMethod) : ICommand<ErrorOr<CheckoutOrderCommandResult>>;
