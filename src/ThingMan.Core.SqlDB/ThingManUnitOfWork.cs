using ThingMan.Core.SqlDB.Repositories;

namespace ThingMan.Core.SqlDB;

public class ThingManUnitOfWork : UnitOfWork<ThingManDbContext>, IThingManUnitOfWork
{
    private readonly ThingManDbContext _dbContext;

    public ThingManUnitOfWork(ThingManDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public IThingDefsRepository ThingDefsRepository => new ThingDefsRepository(_dbContext);
}