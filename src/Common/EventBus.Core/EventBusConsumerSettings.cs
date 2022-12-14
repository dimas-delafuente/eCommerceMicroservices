namespace EventBus.Core;

public sealed class EventBusConsumerSettings
{
    public string Queue { get; private set; } = null!;
    public Type Type { get; private set; } = null!;

    private EventBusConsumerSettings(string queue, Type type)
    {
        Queue = queue;
        Type = type;
    }

    public static EventBusConsumerSettings From(string queue, Type type) => new EventBusConsumerSettings(queue, type);
}
