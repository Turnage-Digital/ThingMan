using MediatR;
using ThingMan.Core;

namespace ThingMan.Application.Queries;

public class GetThingDefByIdQueryHandler<TThingDef> : IRequestHandler<GetThingDefByIdQuery<TThingDef>, TThingDef>
    where TThingDef : IReadOnlyThingDef
{
    private readonly IGetReadOnlyThingDefById<TThingDef> _getReadOnlyThingDefById;

    protected GetThingDefByIdQueryHandler(
        IGetReadOnlyThingDefById<TThingDef> getReadOnlyThingDefById
    )
    {
        _getReadOnlyThingDefById = getReadOnlyThingDefById;
    }

    public async Task<TThingDef> Handle(
        GetThingDefByIdQuery<TThingDef> request,
        CancellationToken cancellationToken = default
    )
    {
        var retval = await _getReadOnlyThingDefById.GetAsync(request.Id, cancellationToken);
        return retval;
    }
}