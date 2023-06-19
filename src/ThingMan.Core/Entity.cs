using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediatR;

namespace ThingMan.Core;

public abstract class Entity : IEntity
{
    private List<INotification>? _events;

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid? Id { get; set; }

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

public interface IEntity
{
    IEnumerable<INotification>? Events { get; }

    void AddEvent(INotification notification);

    void RemoveEvent(INotification notification);

    void ClearEvents();
}