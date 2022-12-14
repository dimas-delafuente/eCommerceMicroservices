using EventBus.Messages.Events;

namespace EventBus.Core.Services;

public interface IEventBus
{
    Task Publish(IIntegrationEvent integrationEvent);
}
