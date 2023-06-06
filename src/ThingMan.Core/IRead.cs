namespace ThingMan.Core;

public interface IRead<T>
{
    Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken);

    Task<T?> ReadAsync(Guid id, CancellationToken cancellationToken);
}