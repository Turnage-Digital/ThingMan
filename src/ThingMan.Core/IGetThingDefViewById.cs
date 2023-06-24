namespace ThingMan.Core;

public interface IGetThingDefViewById
{
    Task<IReadOnlyThingDef> GetAsync(string id, CancellationToken cancellationToken);
}