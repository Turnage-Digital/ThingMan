namespace ThingMan.Core;

public interface IRead<T>
{
    Task<bool> ExistsAsync(string id, CancellationToken cancellationToken);

    Task<T?> ReadAsync(string id, CancellationToken cancellationToken);
}