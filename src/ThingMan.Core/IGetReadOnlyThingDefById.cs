namespace ThingMan.Core;

public interface IGetReadOnlyThingDefById<TThingDef>
    where TThingDef : IReadOnlyThingDef

{
    Task<TThingDef> GetAsync(string id, CancellationToken cancellationToken = default);
}