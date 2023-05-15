using MediatR;
using Microsoft.EntityFrameworkCore;
using ThingMan.Core;
using ThingMan.Domain;

namespace ThingMan.Impl.SqlDB;

public class ThingManDbContext : DbContext
{
    private readonly IMediator _mediator;

    public ThingManDbContext(DbContextOptions<ThingManDbContext> options, IMediator mediator)
        : base(options)
    {
        _mediator = mediator;
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
            await _mediator.Publish(notification);
        }
    }
}