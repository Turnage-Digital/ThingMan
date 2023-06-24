using ThingMan.Core.SqlDB.Entities;

namespace ThingMan.Core.SqlDB;

internal class ThingDefsStore : IThingDefsStore<IWritableThingDef>
{
    private readonly ThingManDbContext _dbContext;

    public ThingDefsStore(ThingManDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IWritableThingDef?> ReadAsync(string id, CancellationToken cancellationToken)
    {
        var retval = await _dbContext.ThingDefs
            .FindAsync(new object?[] { id }, cancellationToken);
        return retval;
    }

    public async Task CreateAsync(IWritableThingDef entity, CancellationToken cancellationToken)
    {
        await _dbContext.ThingDefs.AddAsync((ThingDefEntity)entity, cancellationToken);
    }
}