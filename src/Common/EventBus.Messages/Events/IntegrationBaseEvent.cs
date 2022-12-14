namespace EventBus.Messages.Events;

public record IntegrationBaseEvent
{
	public Guid EventId { get; private set; }
	public DateTime CreationDateUtc { get; private set; }

	public IntegrationBaseEvent()
	{
		EventId = Guid.NewGuid();
		CreationDateUtc = DateTime.UtcNow;
	}
}
