using Common.Primitives;
using Common.Primitives.Commands;
using ErrorOr;
using Orders.Domain.Abstractions.Repositories;
using Orders.Domain.Errors;

namespace Orders.Application.Features.Orders.Commands.DeleteOrder;

internal sealed class DeleteOrderCommandHandler : ICommandHandler<DeleteOrderCommand, ErrorOr<DeleteOrderCommandResult>>
{
    private readonly IOrderRepository _orderRepository;

    public DeleteOrderCommandHandler(IOrderRepository orderRepository)
    {
        Ensure.NotNull(orderRepository, nameof(orderRepository));
        _orderRepository = orderRepository;
    }

    public async Task<ErrorOr<DeleteOrderCommandResult>> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.Id);
        if (order is null)
        {
            return Errors.Order.NotFound;
        }

        await _orderRepository.DeleteAsync(order);

        return new DeleteOrderCommandResult();
    }
}
