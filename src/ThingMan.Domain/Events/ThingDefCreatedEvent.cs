using MediatR;
using ThingMan.Core;

namespace ThingMan.Domain.Events;

public class ThingDefCreatedEvent<TThingDef, TKey> : INotification
    where TThingDef : IThingDef<TKey>
{
    public TThingDef ThingDef { get; set; } = default!;
}