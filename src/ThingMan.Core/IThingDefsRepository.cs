using ThingMan.Core.Entities;

namespace ThingMan.Core;

public interface IThingDefsRepository
{
    Task<ThingDef?> ReadAsync(Guid id, CancellationToken cancellationToken);

    Task CreateAsync(ThingDef entity, CancellationToken cancellationToken);
}