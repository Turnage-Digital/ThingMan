using MediatR;

namespace ThingMan.Domain.Events;

internal class ThingDefCreatedEventHandler<TKey> : INotificationHandler<ThingDefCreatedEvent<TKey>>
{
    public async Task Handle(ThingDefCreatedEvent<TKey> notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}