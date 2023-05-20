namespace ThingMan.Core;

public interface IDelete<in T>
{
    Task DeleteAsync(T entity);
}