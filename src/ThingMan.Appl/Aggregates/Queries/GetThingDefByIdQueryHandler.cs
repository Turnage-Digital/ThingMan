using MediatR;
using ThingMan.Domain.Aggregates.ThingDefs;
using ThingMan.Domain.Aggregates.ThingDefs.Dtos;

namespace ThingMan.Appl.Aggregates.Queries;

internal class GetThingDefByIdQueryHandler : IRequestHandler<GetThingDefByIdQuery, ThingDefDto>
{
    private readonly IThingDefsView _thingDefsView;

    public GetThingDefByIdQueryHandler(IThingDefsView thingDefsView)
    {
        _thingDefsView = thingDefsView;
    }

    public async Task<ThingDefDto> Handle(GetThingDefByIdQuery request, CancellationToken cancellationToken)
    {
        return await _thingDefsView.GetById(request.Id);
    }
}