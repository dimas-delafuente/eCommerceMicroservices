using Common.Primitives.Commands;

namespace Orders.Application.Features.Orders.Commands.CheckoutOrder;

public sealed record CheckoutOrderCommandResult(Guid OrderId) : ICommandResult;