namespace ThingMan.App;

public interface IUnitOfWork : IDisposable
{
    void BeginTransaction();

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}