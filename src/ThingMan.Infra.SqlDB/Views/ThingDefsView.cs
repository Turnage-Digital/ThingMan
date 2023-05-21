using AutoMapper;
using ThingMan.Domain;
using ThingMan.Domain.Dtos;

namespace ThingMan.Infra.SqlDB.Views;

internal class ThingDefsView : IThingDefsView
{
    private readonly IMapper _mapper;
    private readonly IThingDefsRepository _thingDefsRepository;

    public ThingDefsView(IThingDefsRepository thingDefsRepository, IMapper mapper)
    {
        _thingDefsRepository = thingDefsRepository;
        _mapper = mapper;
    }

    public async Task<ThingDefDto> GetById(string id)
    {
        var entity = await _thingDefsRepository.ReadAsync(id);
        var retval = _mapper.Map<ThingDefDto>(entity);
        return retval;
    }
}