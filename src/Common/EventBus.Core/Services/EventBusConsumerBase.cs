using EventBus.Messages.Events;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace EventBus.Core.Services
{
    public abstract class EventBusConsumerBase<TEvent> : IEventConsumer<TEvent>
        where TEvent : IntegrationBaseEvent
    {
        private readonly ILogger _logger;

        public EventBusConsumerBase(ILogger logger)
        {
            _logger = logger;
        }

        protected abstract Task ConsumeEvent(TEvent integrationEvent);

        public async Task Consume(ConsumeContext<TEvent> context)
        {
            _logger.LogInformation("Processing event {eventName} (Id: {eventId})", nameof(TEvent), context.MessageId);

            await ConsumeEvent(context.Message);

            _logger.LogInformation("{eventName} (Id: {eventId}) consumed successfully.", nameof(TEvent));

        }
    }
}
