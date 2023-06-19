using AutoMapper;
using ThingMan.Core.Views;

namespace ThingMan.Core.SqlDB.Views;

internal class ThingDefsView : IThingDefsView
{
    private readonly IMapper _mapper;
    private readonly IThingDefsRepository _thingDefsRepository;

    public ThingDefsView(IThingDefsRepository thingDefsRepository, IMapper mapper)
    {
        _thingDefsRepository = thingDefsRepository;
        _mapper = mapper;
    }

    public async Task<ThingDefView> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _thingDefsRepository.ReadAsync(id, cancellationToken);
        var retval = _mapper.Map<ThingDefView>(entity);
        return retval;
    }
}