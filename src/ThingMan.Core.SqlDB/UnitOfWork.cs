using Microsoft.EntityFrameworkCore;

namespace ThingMan.Core.SqlDB;

public class UnitOfWork<TContext> : IUnitOfWork
    where TContext : DbContext
{
    private readonly TContext _dbContext;

    private bool _disposed;

    public UnitOfWork(TContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var retval = await _dbContext.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return retval;
        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken)!;
            throw;
        }
        finally
        {
            transaction.Dispose();
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }

        _disposed = true;
    }
}