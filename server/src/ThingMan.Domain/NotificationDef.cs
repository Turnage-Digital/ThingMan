using ThingMan.Core;

namespace ThingMan.Domain;

public class NotificationDef : Entity
{
    public NotificationType Type { get; set; }

    public bool IsActive { get; set; }

    public string? UserId { get; set; }
}