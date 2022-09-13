using Common.Primitives.Domain;

namespace Catalog.Domain.Events;

public sealed record ProductUpdatedDomainEvent(Guid ProductId) : IDomainEvent;
