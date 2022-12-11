using Common.Primitives;
using Common.Primitives.Commands;
using Common.Primitives.Enumerations;
using Common.Primitives.ValueObjects;
using ErrorOr;
using Orders.Domain.Abstractions.Repositories;
using Orders.Domain.Entities;
using Orders.Domain.Errors;
using Orders.Domain.ValueObjects;

namespace Orders.Application.Features.Orders.Commands.CheckoutOrder;

internal sealed class CheckoutOrderCommandHandler : ICommandHandler<CheckoutOrderCommand, ErrorOr<CheckoutOrderCommandResult>>
{
    private readonly IOrderRepository _orderRepository;

    public CheckoutOrderCommandHandler(IOrderRepository orderRepository)
    {
        Ensure.NotNull(orderRepository, nameof(orderRepository));
        _orderRepository = orderRepository;
    }

    public async Task<ErrorOr<CheckoutOrderCommandResult>> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
    {
        var totalPrice = Price.From(request.TotalPrice, Currency.Euro);
        var billingAddress = BillingAddress.From(request.FirstName, request.LastName, request.EmailAddress, request.AddressLine, request.Country, request.State, request.ZipCode);
        var paymentDetails = PaymentDetails.From(request.CardName, request.CardName, request.Expiration, request.Ccv, request.PaymentMethod);

        var orderEntity = Order.Create(request.UserName, totalPrice, billingAddress, paymentDetails);
        orderEntity.Checkout();

        var newOrder = await _orderRepository.AddAsync(orderEntity);

        return newOrder is not null ? (ErrorOr<CheckoutOrderCommandResult>)new CheckoutOrderCommandResult(newOrder.Id) : (ErrorOr<CheckoutOrderCommandResult>)Errors.Order.CheckoutError;
    }
}
