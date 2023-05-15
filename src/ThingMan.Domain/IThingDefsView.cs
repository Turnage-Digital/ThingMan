using ThingMan.Domain.Dtos;

namespace ThingMan.Domain;

public interface IThingDefsView
{
    Task<ThingDefDto> GetById(string id);
}