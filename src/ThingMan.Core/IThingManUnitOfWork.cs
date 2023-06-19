namespace ThingMan.Core;

public interface IThingManUnitOfWork : IUnitOfWork
{
    IThingDefsRepository ThingDefsRepository { get; }
}