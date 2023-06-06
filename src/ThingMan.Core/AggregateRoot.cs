using System.ComponentModel.DataAnnotations.Schema;
using MediatR;

namespace ThingMan.Core;

public abstract class AggregateRoot : Entity, IAggregateRoot
{
    private List<INotification>? _events;

    [NotMapped]
    public IEnumerable<INotification>? Events => _events?.AsReadOnly();

    public void AddEvent(INotification notification)
    {
        _events ??= new List<INotification>();
        _events.Add(notification);
    }

    public void RemoveEvent(INotification notification)
    {
        _events?.Remove(notification);
    }

    public void ClearEvents()
    {
        _events?.Clear();
    }
}