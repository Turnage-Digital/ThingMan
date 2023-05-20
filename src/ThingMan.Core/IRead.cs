namespace ThingMan.Core;

public interface IRead<T>
{
    Task<bool> ExistsAsync(string id);

    Task<T?> ReadAsync(string id);
}