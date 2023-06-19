using System.ComponentModel.DataAnnotations;

namespace ThingMan.Core.Entities;

public class StatusDef : Entity
{
    [Required]
    public string Name { get; set; } = null!;
}