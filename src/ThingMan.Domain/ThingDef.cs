using System.ComponentModel.DataAnnotations;
using ThingMan.Core;
using ThingMan.Domain.Events;

namespace ThingMan.Domain;

public class ThingDef : AggregateRoot
{
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string UserId { get; set; } = null!;

    public ICollection<StatusDef> StatusDefs { get; set; } = null!;

    public ICollection<NotificationDef> NotificationDefs { get; set; } = null!;

    public PropertyDef? PropertyDef1 { get; set; }

    public PropertyDef? PropertyDef2 { get; set; }

    public PropertyDef? PropertyDef3 { get; set; }

    public static ThingDef Create(
        string name,
        string userId,
        StatusDef[] statuses,
        NotificationDef[] notificationDefs,
        PropertyDef? propertyDef1 = null,
        PropertyDef? propertyDef2 = null,
        PropertyDef? propertyDef3 = null
    )
    {
        var retval = new ThingDef
        {
            Name = name,
            UserId = userId,
            StatusDefs = statuses,
            NotificationDefs = notificationDefs,
            PropertyDef1 = propertyDef1,
            PropertyDef2 = propertyDef2,
            PropertyDef3 = propertyDef3
        };
        retval.AddNotification(new ThingDefCreatedEvent { ThingDef = retval });
        return retval;
    }
}