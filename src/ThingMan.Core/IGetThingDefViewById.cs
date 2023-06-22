namespace ThingMan.Core;

public interface IGetThingDefViewById<TKey>
{
    Task<IThingDef<TKey>> Get(TKey id, CancellationToken cancellationToken);
}