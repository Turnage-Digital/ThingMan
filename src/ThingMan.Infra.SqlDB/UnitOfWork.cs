using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ThingMan.Infra.SqlDB;

public interface IUnitOfWork<TContext> : IDisposable
    where TContext : DbContext
{
    Task<int> SaveChangesAsync();
}

public class UnitOfWork<TContext> : IUnitOfWork<TContext>
    where TContext : DbContext
{
    private readonly TContext _dbContext;
    private IDbContextTransaction _transaction = null!;

    public UnitOfWork(TContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> SaveChangesAsync()
    {
        try
        {
            var result = await _dbContext.SaveChangesAsync();
            await _transaction.CommitAsync();
            return result;
        }
        catch
        {
            await _transaction.RollbackAsync();
            throw;
        }
        finally
        {
            _transaction.Dispose();
        }
    }

    public void Dispose()
    {
        _transaction.Dispose();
        _dbContext.Dispose();
    }

    public void BeginTransaction()
    {
        _transaction = _dbContext.Database.BeginTransaction();
    }
}