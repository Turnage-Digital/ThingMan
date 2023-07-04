using Microsoft.EntityFrameworkCore;
using ThingMan.Core.SqlDB.Entities;

namespace ThingMan.Core.SqlDB;

public class ThingManDbContext : DbContext
{
    public virtual DbSet<ThingDefEntity> ThingDefs { get; set; } = null!;

    public ThingManDbContext(DbContextOptions<ThingManDbContext> options)
        : base(options) { }
}