using AutoMapper;
using EventBus.Core.Services;
using EventBus.Messages.Events;
using MediatR;
using Orders.Application.Features.Orders.Commands.CheckoutOrder;

namespace Orders.API.EventBusConsumers;

public class BasketCheckoutConsumer : EventBusConsumerBase<BasketCheckoutEvent>
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;
    private readonly ILogger<BasketCheckoutConsumer> _logger;

    public BasketCheckoutConsumer(ISender mediator, IMapper mapper, ILogger<BasketCheckoutConsumer> logger)
        : base(logger)
    {
        _mediator = mediator;
        _mapper = mapper;
        _logger = logger;
    }

    protected override async Task ConsumeEvent(BasketCheckoutEvent integrationEvent)
    {
        var command = _mapper.Map<CheckoutOrderCommand>(integrationEvent);
        var result = await _mediator.Send(command);

        if (!result.IsError)
        {
            _logger.LogInformation("Event: {eventName}. Created Order Id : {newOrderId}", nameof(BasketCheckoutEvent), result.Value.OrderId);
        }
    }
}
