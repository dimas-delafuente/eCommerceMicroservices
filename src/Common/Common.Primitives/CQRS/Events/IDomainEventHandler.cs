using Common.Primitives.Domain;
using MediatR;

namespace Common.Primitives.CQRS.Events;

public interface IDomainEventHandler<TDomainEvent> : INotificationHandler<TDomainEvent>
    where TDomainEvent : IDomainEvent
{
}
