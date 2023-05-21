using ThingMan.Domain;

namespace ThingMan.App;

public interface IThingManUnitOfWork : IUnitOfWork
{
    IThingDefsRepository ThingDefsRepository { get; }
}