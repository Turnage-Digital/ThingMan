using ThingMan.Contracts.Dtos;

namespace ThingMan.Core;

public interface IThingDefsView
{
    Task<ThingDefDto> GetById(Guid id, CancellationToken cancellationToken);
}