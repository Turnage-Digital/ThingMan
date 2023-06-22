using ThingMan.Core;

namespace ThingMan.Domain;

public class ThingDefAggregate<TThingDef, TKey>
    where TThingDef : IThingDef<TKey>
{
    private readonly IThingDefsStore<TThingDef, TKey> _store;

    public ThingDefAggregate(IThingDefsStore<TThingDef, TKey> store)
    {
        _store = store;
    }

    public async Task Create(TThingDef thingDef, CancellationToken cancellationToken = default)
    {
        await _store.CreateAsync(thingDef, cancellationToken);
    }

    // public static ThingDefAggregate Create(
    //     string name,
    //     string userId,
    //     ICollection<StatusDef> statusDefs,
    //     ICollection<NotificationDef> notificationDefs,
    //     PropertyDef? propertyDef1 = null,
    //     PropertyDef? propertyDef2 = null,
    //     PropertyDef? propertyDef3 = null,
    //     PropertyDef? propertyDef4 = null,
    //     PropertyDef? propertyDef5 = null
    // )
    // {
    //     var retval = new ThingDefAggregate
    //     {
    //         Name = name,
    //         UserId = userId,
    //         StatusDefs = statusDefs,
    //         NotificationDefs = notificationDefs,
    //         PropertyDef1 = propertyDef1,
    //         PropertyDef2 = propertyDef2,
    //         PropertyDef3 = propertyDef3,
    //         PropertyDef4 = propertyDef4,
    //         PropertyDef5 = propertyDef5
    //     };
    //
    //     // retval.AddEvent(new ThingDefCreatedEvent { ThingDefAggregate = retval });
    //
    //     return retval;
    // }
}