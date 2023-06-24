using MediatR;
using ThingMan.Core;

namespace ThingMan.App.Queries;

public class GetThingDefByIdQueryHandler : IRequestHandler<GetThingDefByIdQuery, IReadOnlyThingDef>
{
    private readonly IGetThingDefViewById _getThingDefViewById;

    public GetThingDefByIdQueryHandler(IGetThingDefViewById getThingDefViewById)
    {
        _getThingDefViewById = getThingDefViewById;
    }

    public async Task<IReadOnlyThingDef> Handle(GetThingDefByIdQuery request, CancellationToken cancellationToken)
    {
        var retval = await _getThingDefViewById.GetAsync(request.Id, cancellationToken);
        return retval;
    }
}