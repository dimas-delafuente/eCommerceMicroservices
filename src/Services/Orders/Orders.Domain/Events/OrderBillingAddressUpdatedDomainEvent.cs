using Common.Primitives.Domain;

namespace Orders.Domain.Events;

public sealed record OrderBillingAddressUpdatedDomainEvent(Guid OrderId) : IDomainEvent;
