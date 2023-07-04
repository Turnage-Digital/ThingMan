using ThingMan.Core.ValueObjects;

namespace ThingMan.Core;

public interface IThingDefsStore<TThingDef>
    where TThingDef : IWritableThingDef
{
    Task<TThingDef> InitAsync(CancellationToken cancellationToken);

    Task CreateAsync(TThingDef thingDef, CancellationToken cancellationToken);

    Task<TThingDef?> ReadAsync(string id, CancellationToken cancellationToken);

    Task SetNameAsync(TThingDef thingDef, string name, CancellationToken cancellationToken);

    Task<string> GetNameAsync(TThingDef thingDef, CancellationToken cancellationToken);

    Task SetStatusDefsAsync(TThingDef thingDef, StatusDef[] statusDefs, CancellationToken cancellationToken);

    Task<StatusDef[]> GetStatusDefsAsync(TThingDef thingDef, CancellationToken cancellationToken);

    Task SetPropertyDef1Async(TThingDef thingDef, PropertyDef? propertyDef, CancellationToken cancellationToken);

    Task<PropertyDef?> GetPropertyDef1Async(TThingDef thingDef, CancellationToken cancellationToken);

    Task SetPropertyDef2Async(TThingDef thingDef, PropertyDef? propertyDef, CancellationToken cancellationToken);

    Task<PropertyDef?> GetPropertyDef2Async(TThingDef thingDef, CancellationToken cancellationToken);

    Task SetPropertyDef3Async(TThingDef thingDef, PropertyDef? propertyDef, CancellationToken cancellationToken);

    Task<PropertyDef?> GetPropertyDef3Async(TThingDef thingDef, CancellationToken cancellationToken);

    Task SetPropertyDef4Async(TThingDef thingDef, PropertyDef? propertyDef, CancellationToken cancellationToken);

    Task<PropertyDef?> GetPropertyDef4Async(TThingDef thingDef, CancellationToken cancellationToken);

    Task SetPropertyDef5Async(TThingDef thingDef, PropertyDef? propertyDef, CancellationToken cancellationToken);

    Task<PropertyDef?> GetPropertyDef5Async(TThingDef thingDef, CancellationToken cancellationToken);
}