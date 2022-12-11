using Common.Primitives;
using Common.Primitives.CQRS.Events;
using Common.Primitives.Domain.ValueObjects;
using Orders.Application.Services;
using Orders.Domain.Abstractions.Repositories;
using Orders.Domain.Events;

namespace Orders.Application.Features.Orders.Events;

internal sealed class OrderCheckoutDomainEventHandler : IDomainEventHandler<OrderCheckoutDomainEvent>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IEmailService _emailService;

    public OrderCheckoutDomainEventHandler(IOrderRepository orderRepository, IEmailService emailService)
    {
        Ensure.NotNull(orderRepository, nameof(orderRepository));
        Ensure.NotNull(emailService, nameof(emailService));

        _orderRepository = orderRepository;
        _emailService = emailService;
    }

    public async Task Handle(OrderCheckoutDomainEvent notification, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(notification.OrderId);
        if (order is not null)
        {
            var email = Email.From(order.BillingAddress.EmailAddress, "Order created.", $"Order {notification.OrderId} was created");
            await _emailService.SendEmail(email);
        }
    }
}
