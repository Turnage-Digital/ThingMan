using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThingMan.Core.SqlDB.Entities;

[Table("ThingDef")]
public class ThingDefEntity : IWritableThingDef
{
    [Required]
    public string Name { get; set; } = null!;

    public ICollection<StatusDefEntity> StatusDefs { get; set; } = null!;

    public PropertyDefEntity? PropertyDef1 { get; set; }

    public PropertyDefEntity? PropertyDef2 { get; set; }

    public PropertyDefEntity? PropertyDef3 { get; set; }

    public PropertyDefEntity? PropertyDef4 { get; set; }

    public PropertyDefEntity? PropertyDef5 { get; set; }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; } = null!;
}