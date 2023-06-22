using AutoMapper;
using ThingMan.Core.SqlDB.Entities;
using ThingMan.Core.SqlDB.Views;

namespace ThingMan.Core.SqlDB;

internal class GetThingDefViewById : IGetThingDefViewById<Guid>
{
    private readonly IMapper _mapper;
    private readonly IThingDefsStore<ThingDefEntity, Guid> _thingDefsStore;

    public GetThingDefViewById(IThingDefsStore<ThingDefEntity, Guid> thingDefsStore, IMapper mapper)
    {
        _thingDefsStore = thingDefsStore;
        _mapper = mapper;
    }

    public async Task<IThingDef<Guid>> Get(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _thingDefsStore.ReadAsync(id, cancellationToken);
        var retval = _mapper.Map<ThingDefView<Guid>>(entity);
        return retval;
    }
}