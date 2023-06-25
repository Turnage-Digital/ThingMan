namespace ThingMan.Core;

public interface IGetReadOnlyThingDefById
{
    Task<IReadOnlyThingDef> GetAsync(string id, CancellationToken cancellationToken = default);
}