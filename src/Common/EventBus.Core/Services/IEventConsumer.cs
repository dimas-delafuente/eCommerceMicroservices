using EventBus.Messages.Events;
using MassTransit;

namespace EventBus.Core.Services;

public interface IEventConsumer<TEvent> : IConsumer<TEvent>
    where TEvent : IntegrationBaseEvent
{
}
