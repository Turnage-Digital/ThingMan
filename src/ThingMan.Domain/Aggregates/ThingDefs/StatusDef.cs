using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThingMan.Domain.Aggregates.ThingDefs;

public record StatusDef
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string? Id { get; set; } = null;

    [Required]
    public string Name { get; set; } = null!;
}