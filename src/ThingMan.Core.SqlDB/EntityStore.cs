using Microsoft.EntityFrameworkCore;

namespace ThingMan.Core.SqlDB;

internal class EntityStore<TEntity>
    where TEntity : class
{
    private readonly DbContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;

    public EntityStore(DbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<TEntity>();
    }

    public async Task CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
    }

    public ValueTask<TEntity?> ReadAsync(object id, CancellationToken cancellationToken = default)
    {
        return _dbSet.FindAsync(new[] { id }, cancellationToken: cancellationToken);
    }

    public void Update(TEntity entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }
}