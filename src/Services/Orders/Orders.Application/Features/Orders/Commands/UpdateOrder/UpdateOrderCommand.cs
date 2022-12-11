using Common.Primitives.Commands;
using ErrorOr;

namespace Orders.Application.Features.Orders.Commands.UpdateOrder;

public sealed record UpdateOrderCommand(
    Guid Id,
    string FirstName,
    string LastName,
    string EmailAddress,
    string AddressLine,
    string Country,
    string State,
    string ZipCode) : ICommand<ErrorOr<UpdateOrderCommandResult>>;
