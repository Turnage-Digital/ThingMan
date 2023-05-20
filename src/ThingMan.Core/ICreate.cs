namespace ThingMan.Core;

public interface ICreate<in T>
{
    Task CreateAsync(T entity);
}