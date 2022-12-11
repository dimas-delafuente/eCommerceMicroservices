using Common.Primitives.Domain;

namespace Orders.Domain.Events;

public sealed record OrderCheckoutDomainEvent(Guid OrderId) : IDomainEvent;
