namespace ThingMan.Core;

public interface IThingDefsStore<TThingDef, in TKey>
    where TThingDef : IThingDef<TKey>
{
    Task<TThingDef?> ReadAsync(TKey id, CancellationToken cancellationToken);

    Task CreateAsync(TThingDef thingDef, CancellationToken cancellationToken);
}