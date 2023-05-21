using Microsoft.EntityFrameworkCore;
using ThingMan.Domain;

namespace ThingMan.Infra.SqlDB.Repositories;

internal class ThingDefsRepository : IThingDefsRepository
{
    private readonly ThingManDbContext _dbContext;

    public ThingDefsRepository(ThingManDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> ExistsAsync(string id)
    {
        var retval = await _dbContext.ThingDefs
            .AnyAsync(x => x.Id == id);
        return retval;
    }

    public async Task<ThingDef?> ReadAsync(string id)
    {
        var retval = await _dbContext.ThingDefs
            .FindAsync(id);
        return retval;
    }

    public async Task CreateAsync(ThingDef entity)
    {
        _dbContext.ThingDefs.Add(entity);
        await _dbContext.SaveChangesAsync();
    }
}