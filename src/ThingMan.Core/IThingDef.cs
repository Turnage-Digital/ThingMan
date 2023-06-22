namespace ThingMan.Core;

public interface IThingDef<TKey>
{
    TKey Id { get; set; }
}