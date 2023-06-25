using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThingMan.Core.SqlDB.Entities;

[Table("NotificationDef")]
public class NotificationDefEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid? Id { get; set; }

    [Required]
    public string Type { get; set; } = null!;

    [Required]
    public bool IsActive { get; set; }

    public string? UserId { get; set; }
}