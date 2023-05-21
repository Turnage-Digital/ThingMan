namespace ThingMan.Core;

public interface IUpdate<in T>
{
    Task UpdateAsync(T entity, CancellationToken cancellationToken);
}