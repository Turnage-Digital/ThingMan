using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using ThingMan.Core;
using ThingMan.Domain.Aggregates.ThingDefs;

namespace ThingMan.Domain.SqlDB;

public class ThingManDbContext : DbContext
{
    private readonly IMediator _dispatcher;

    public ThingManDbContext(DbContextOptions<ThingManDbContext> options, IMediator dispatcher)
        : base(options)
    {
        _dispatcher = dispatcher;
    }

    public virtual DbSet<ThingDef> ThingDefs { get; set; } = null!;

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var retval = await base.SaveChangesAsync(cancellationToken);
        await DispatchEventsAsync();
        return retval;
    }

    private async Task DispatchEventsAsync()
    {
        var entities = ChangeTracker
            .Entries<Entity>()
            .Where(entity => entity.Entity.Notifications != null && entity.Entity.Notifications.Any())
            .ToList();

        var notifications = entities
            .SelectMany(entry => entry.Entity.Notifications!)
            .ToList();

        foreach (var entity in entities)
        {
            entity.Entity.ClearNotifications();
        }

        foreach (var notification in notifications)
        {
            await _dispatcher.Publish(notification);
        }
    }
}