using MediatR;
using ThingMan.Core;

namespace ThingMan.App.Queries;

public class GetThingDefByIdQueryHandler : IRequestHandler<GetThingDefByIdQuery, IReadOnlyThingDef>
{
    private readonly IGetReadOnlyThingDefById _getReadOnlyThingDefById;

    public GetThingDefByIdQueryHandler(IGetReadOnlyThingDefById getReadOnlyThingDefById)
    {
        _getReadOnlyThingDefById = getReadOnlyThingDefById;
    }

    public async Task<IReadOnlyThingDef> Handle(
        GetThingDefByIdQuery request, CancellationToken cancellationToken = default
    )
    {
        var retval = await _getReadOnlyThingDefById.GetAsync(request.Id, cancellationToken);
        return retval;
    }
}