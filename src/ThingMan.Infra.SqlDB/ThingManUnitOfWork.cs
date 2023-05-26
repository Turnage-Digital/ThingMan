using ThingMan.App;
using ThingMan.Domain;
using ThingMan.Infra.SqlDB.Repositories;

namespace ThingMan.Infra.SqlDB;

public class ThingManUnitOfWork : UnitOfWork<ThingManDbContext>, IThingManUnitOfWork
{
    private readonly ThingManDbContext _dbContext;

    public ThingManUnitOfWork(ThingManDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public IThingDefsRepository ThingDefsRepository => new ThingDefsRepository(_dbContext);
}