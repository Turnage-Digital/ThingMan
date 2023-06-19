using System.ComponentModel.DataAnnotations;

namespace ThingMan.Core.Entities;

public class NotificationDef : Entity
{
    [Required]
    public NotificationType Type { get; set; }

    [Required]
    public bool IsActive { get; set; }

    public string? UserId { get; set; }
}