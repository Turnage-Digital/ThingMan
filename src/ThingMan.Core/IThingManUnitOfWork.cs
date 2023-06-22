namespace ThingMan.Core;

public interface IThingManUnitOfWork<TThingDef, in TKey> : IUnitOfWork
    where TThingDef : IThingDef<TKey>
{
    IThingDefsStore<TThingDef, TKey> ThingDefsStore { get; }
}