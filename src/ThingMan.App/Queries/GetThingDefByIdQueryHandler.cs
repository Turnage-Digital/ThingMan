using MediatR;
using ThingMan.Domain;
using ThingMan.Domain.Dtos;

namespace ThingMan.App.Queries;

public class GetThingDefByIdQueryHandler : IRequestHandler<GetThingDefByIdQuery, ThingDefDto>
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