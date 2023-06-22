using MediatR;
using ThingMan.Core;

namespace ThingMan.Domain.Events;

internal class
    ThingDefCreatedEventHandler<TThingDef, TKey> : INotificationHandler<ThingDefCreatedEvent<TThingDef, TKey>>
    where TThingDef : IThingDef<TKey>
{
    public async Task Handle(ThingDefCreatedEvent<TThingDef, TKey> notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}