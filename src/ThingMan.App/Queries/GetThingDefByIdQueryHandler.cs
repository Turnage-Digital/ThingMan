using MediatR;
using ThingMan.Core;
using ThingMan.Core.Views;

namespace ThingMan.App.Queries;

public class GetThingDefByIdQueryHandler : IRequestHandler<GetThingDefByIdQuery, ThingDefView>
{
    private readonly IThingDefsView _thingDefsView;

    public GetThingDefByIdQueryHandler(IThingDefsView thingDefsView)
    {
        _thingDefsView = thingDefsView;
    }

    public async Task<ThingDefView> Handle(GetThingDefByIdQuery request, CancellationToken cancellationToken)
    {
        return await _thingDefsView.GetById(request.Id, cancellationToken);
    }
}