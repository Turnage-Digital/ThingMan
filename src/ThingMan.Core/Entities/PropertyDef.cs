using System.ComponentModel.DataAnnotations;

namespace ThingMan.Core.Entities;

public class PropertyDef : Entity
{
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public PropertyType Type { get; set; }
}