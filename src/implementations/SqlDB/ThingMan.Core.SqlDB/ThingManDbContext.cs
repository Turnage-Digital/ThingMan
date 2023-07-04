using Microsoft.EntityFrameworkCore;
using ThingMan.Core.SqlDB.Entities;

namespace ThingMan.Core.SqlDB;

public class ThingManDbContext : DbContext
{
    public ThingManDbContext(DbContextOptions<ThingManDbContext> options)
        : base(options) { }

    public virtual DbSet<ThingDefEntity> ThingDefs { get; set; } = null!;
}