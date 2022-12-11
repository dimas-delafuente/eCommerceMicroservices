using Common.Primitives;
using Common.Primitives.CQRS.Events;
using Common.Primitives.Domain.ValueObjects;
using Orders.Application.Services;
using Orders.Domain.Abstractions.Repositories;
using Orders.Domain.Events;

namespace Orders.Application.Features.Orders.Events;

internal sealed class OrderBillingAddressUpdatedDomainEventHandler : IDomainEventHandler<OrderBillingAddressUpdatedDomainEvent>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IEmailService _emailService;

    public OrderBillingAddressUpdatedDomainEventHandler(IOrderRepository orderRepository, IEmailService emailService)
    {
        Ensure.NotNull(orderRepository, nameof(orderRepository));
        Ensure.NotNull(emailService, nameof(emailService));

        _orderRepository = orderRepository;
        _emailService = emailService;
    }

    public async Task Handle(OrderBillingAddressUpdatedDomainEvent notification, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(notification.OrderId);
        if (order is not null)
        {
            var email = Email.From(order.BillingAddress.EmailAddress, "Order billing address updated.", $"Billing address for Order {notification.OrderId} has been updated.");
            await _emailService.SendEmail(email);
        }
    }
}
