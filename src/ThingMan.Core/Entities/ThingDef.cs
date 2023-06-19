using System.ComponentModel.DataAnnotations;

namespace ThingMan.Core.Entities;

public class ThingDef : Entity
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

    public PropertyDef? PropertyDef4 { get; set; }

    public PropertyDef? PropertyDef5 { get; set; }
}