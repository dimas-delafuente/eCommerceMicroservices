using Common.Primitives.Commands;
using ErrorOr;

namespace Orders.Application.Features.Orders.Commands.DeleteOrder;

public sealed record DeleteOrderCommand(Guid Id) : ICommand<ErrorOr<DeleteOrderCommandResult>>;
