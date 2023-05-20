using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ThingMan.Core;

namespace ThingMan.Domain;

public class StatusDef : Entity
{
    [Required]
    public string Name { get; set; } = null!;
}