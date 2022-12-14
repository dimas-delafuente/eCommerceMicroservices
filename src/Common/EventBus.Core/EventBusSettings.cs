namespace EventBus.Core;

public class EventBusSettings
{
    public string? Host { get; set; }
    public List<EventBusConsumerSettings> Consumers { get; set; } = new List<EventBusConsumerSettings>();
}
