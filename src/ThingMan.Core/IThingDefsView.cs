using ThingMan.Core.Views;

namespace ThingMan.Core;

public interface IThingDefsView
{
    Task<ThingDefView> GetById(Guid id, CancellationToken cancellationToken);
}