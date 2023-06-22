using ThingMan.Core.SqlDB.Entities;

namespace ThingMan.Core.SqlDB;

public class ThingManUnitOfWork : UnitOfWork<ThingManDbContext>, IThingManUnitOfWork<ThingDefEntity, Guid>
{
    private readonly ThingManDbContext _dbContext;

    public ThingManUnitOfWork(ThingManDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public IThingDefsStore<ThingDefEntity, Guid> ThingDefsStore => new ThingDefsStore(_dbContext);
}