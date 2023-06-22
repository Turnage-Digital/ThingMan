using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThingMan.Core.SqlDB.Entities;

[Table("PropertyDef")]
public class PropertyDefEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid? Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string Type { get; set; } = null!;
}