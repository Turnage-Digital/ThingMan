namespace ThingMan.Core;

public interface IThingDefsStore<TThingDef>
    where TThingDef : IWritableThingDef
{
    Task<TThingDef?> ReadAsync(string id, CancellationToken cancellationToken);

    Task CreateAsync(TThingDef thingDef, CancellationToken cancellationToken);
}