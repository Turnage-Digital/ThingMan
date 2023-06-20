using Microsoft.EntityFrameworkCore;
using ThingMan.Core.Entities;

namespace ThingMan.Core.SqlDB.Repositories;

internal class ThingDefsRepository : IThingDefsRepository
{
    private readonly ThingManDbContext _dbContext;

    public ThingDefsRepository(ThingManDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ThingDef?> ReadAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var retval = await _dbContext.ThingDefs
            .FindAsync(new object?[] { id }, cancellationToken);
        return retval;
    }

    public async Task CreateAsync(ThingDef entity, CancellationToken cancellationToken = default)
    {
        await _dbContext.ThingDefs.AddAsync(entity, cancellationToken);
    }
}