using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ThingMan.Core;

namespace ThingMan.Domain;

public class PropertyDef : Entity
{
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public PropertyType Type { get; set; }
}