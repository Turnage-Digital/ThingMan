using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThingMan.Core.SqlDB.Entities;

[Table("ThingDef")]
public class ThingDefEntity : IThingDef<Guid>
{
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string UserId { get; set; } = null!;

    public ICollection<StatusDefEntity> StatusDefs { get; set; } = null!;

    public ICollection<NotificationDefEntity> NotificationDefs { get; set; } = null!;

    public PropertyDefEntity? PropertyDef1 { get; set; }

    public PropertyDefEntity? PropertyDef2 { get; set; }

    public PropertyDefEntity? PropertyDef3 { get; set; }

    public PropertyDefEntity? PropertyDef4 { get; set; }

    public PropertyDefEntity? PropertyDef5 { get; set; }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
}