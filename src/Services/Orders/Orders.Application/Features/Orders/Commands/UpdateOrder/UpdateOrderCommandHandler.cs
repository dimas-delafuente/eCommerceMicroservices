using Common.Primitives;
using Common.Primitives.Commands;
using ErrorOr;
using Orders.Domain.Abstractions.Repositories;
using Orders.Domain.Errors;
using Orders.Domain.ValueObjects;

namespace Orders.Application.Features.Orders.Commands.UpdateOrder;

internal sealed class UpdateOrderCommandHandler : ICommandHandler<UpdateOrderCommand, ErrorOr<UpdateOrderCommandResult>>
{
    private readonly IOrderRepository _orderRepository;

    public UpdateOrderCommandHandler(IOrderRepository orderRepository)
    {
        Ensure.NotNull(orderRepository, nameof(orderRepository));
        _orderRepository = orderRepository;
    }

    public async Task<ErrorOr<UpdateOrderCommandResult>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.Id);
        if (order is null)
        {
            return Errors.Order.NotFound;
        }

        var newBillingAddress = BillingAddress.From(request.FirstName, request.LastName, request.EmailAddress, request.AddressLine, request.Country, request.State, request.ZipCode);
        order.UpdateBillingAddress(newBillingAddress);

        await _orderRepository.UpdateAsync(order);

        return new UpdateOrderCommandResult();
    }
}
