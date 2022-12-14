using AutoMapper;
using EventBus.Core.Services;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Orders.Application.Features.Orders.Commands.CheckoutOrder;

namespace Orders.API.EventBusConsumers;

public class BasketCheckoutConsumer : IEventConsumer<BasketCheckoutEvent>
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;
    private readonly ILogger<BasketCheckoutConsumer> _logger;

    public BasketCheckoutConsumer(ISender mediator, IMapper mapper, ILogger<BasketCheckoutConsumer> logger)
    {
        _mediator = mediator;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
    {
        _logger.LogInformation("Processing event {eventName} (Id: {eventId})", nameof(BasketCheckoutEvent), context.MessageId);

        var command = _mapper.Map<CheckoutOrderCommand>(context.Message);
        var result = await _mediator.Send(command);

        if (!result.IsError)
        {
            _logger.LogInformation("{eventName} (Id: {eventId}) consumed successfully. Created Order Id : {newOrderId}", nameof(BasketCheckoutEvent), context.MessageId, result.Value.OrderId);
        }
    }
}
