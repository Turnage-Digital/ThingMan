using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThingMan.Domain.Aggregates.ThingDefs;

public record PropDef
{
    public PropDef(string name, PropType type)
    {
        Name = name;
        Type = type;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string? Id { get; set; } = null;

    [Required]
    public string Name { get; }

    [Required]
    public PropType Type { get; }
}