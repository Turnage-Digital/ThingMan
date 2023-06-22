using ThingMan.Core.SqlDB.Entities;

namespace ThingMan.Core.SqlDB;

internal class ThingDefsStore : IThingDefsStore<ThingDefEntity, Guid>
{
    private readonly ThingManDbContext _dbContext;

    public ThingDefsStore(ThingManDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ThingDefEntity?> ReadAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var retval = await _dbContext.ThingDefs
            .FindAsync(new object?[] { id }, cancellationToken);
        return retval;
    }

    public async Task CreateAsync(ThingDefEntity entity, CancellationToken cancellationToken = default)
    {
        await _dbContext.ThingDefs.AddAsync(entity, cancellationToken);
    }
}