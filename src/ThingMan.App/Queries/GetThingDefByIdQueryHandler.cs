using MediatR;
using ThingMan.Core;

namespace ThingMan.App.Queries;

public class GetThingDefByIdQueryHandler<TKey> : IRequestHandler<GetThingDefByIdQuery<TKey>, IThingDef<TKey>>
{
    private readonly IGetThingDefViewById<TKey> _getThingDefViewById;

    public GetThingDefByIdQueryHandler(IGetThingDefViewById<TKey> getThingDefViewById)
    {
        _getThingDefViewById = getThingDefViewById;
    }

    public async Task<IThingDef<TKey>> Handle(GetThingDefByIdQuery<TKey> request, CancellationToken cancellationToken)
    {
        var retval = await _getThingDefViewById.Get(request.Id, cancellationToken);
        return retval;
    }
}