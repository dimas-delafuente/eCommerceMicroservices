using EventBus.Messages.Events;
using MassTransit;

namespace EventBus.Core.Services;

internal sealed class EventBus : IEventBus
{
    private readonly IPublishEndpoint _publishEndpoint;

    public EventBus(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public async Task Publish(IIntegrationEvent integrationEvent)
    {
        await _publishEndpoint.Publish(integrationEvent, integrationEvent.GetType());
    }
}
