using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediatR;

namespace ThingMan.Core;

public abstract class Entity
{
    private List<INotification>? _notifications;

    [NotMapped]
    public IEnumerable<INotification>? Notifications => _notifications?.AsReadOnly();

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string? Id { get; set; } = null;

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