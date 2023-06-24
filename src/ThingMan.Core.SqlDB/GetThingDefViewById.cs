using AutoMapper;
using ThingMan.Core.SqlDB.Entities;
using ThingMan.Core.SqlDB.Views;

namespace ThingMan.Core.SqlDB;

internal class GetThingDefViewById : IGetThingDefViewById
{
    private readonly IMapper _mapper;
    private readonly IThingDefsStore<ThingDefEntity> _thingDefsStore;

    public GetThingDefViewById(IThingDefsStore<ThingDefEntity> thingDefsStore, IMapper mapper)
    {
        _thingDefsStore = thingDefsStore;
        _mapper = mapper;
    }

    public async Task<IReadOnlyThingDef> GetAsync(string id, CancellationToken cancellationToken)
    {
        var entity = await _thingDefsStore.ReadAsync(id, cancellationToken);
        var retval = _mapper.Map<ThingDefView>(entity);
        return retval;
    }
}