using MediatR;

namespace ThingMan.Core;

public interface IEntity
{
    IEnumerable<INotification>? Events { get; }

    void AddEvent(INotification notification);

    void RemoveEvent(INotification notification);

    void ClearEvents();
}