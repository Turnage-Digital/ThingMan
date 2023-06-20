using MediatR;
using Microsoft.EntityFrameworkCore;
using ThingMan.Core.Entities;

namespace ThingMan.Core.SqlDB;

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
        await DispatchEventsAsync();
        var retval = await base.SaveChangesAsync(cancellationToken);
        return retval;
    }

    private async Task DispatchEventsAsync()
    {
        var entities = ChangeTracker
            .Entries<IEntity>()
            .Where(changed => changed.Entity.Events != null && changed.Entity.Events.Any())
            .ToList();

        var notifications = entities
            .SelectMany(entry => entry.Entity.Events!)
            .ToList();

        foreach (var entity in entities)
        {
            entity.Entity.ClearEvents();
        }

        foreach (var notification in notifications)
        {
            await _mediator.Publish(notification);
        }
    }
}