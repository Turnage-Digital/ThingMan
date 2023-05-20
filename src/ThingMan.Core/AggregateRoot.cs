using System.ComponentModel.DataAnnotations.Schema;
using MediatR;

namespace ThingMan.Core;

public abstract class AggregateRoot : Entity
{
    private List<INotification>? _notifications;

    [NotMapped]
    public IEnumerable<INotification>? Notifications => _notifications?.AsReadOnly();

    public void AddNotification(INotification notification)
    {
        _notifications ??= new List<INotification>();
        _notifications.Add(notification);
    }

    public void RemoveNotification(INotification notification)
    {
        _notifications?.Remove(notification);
    }

    public void ClearNotifications()
    {
        _notifications?.Clear();
    }
}