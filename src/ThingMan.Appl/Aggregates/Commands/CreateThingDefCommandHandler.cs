using AutoMapper;
using MediatR;
using ThingMan.Domain.Aggregates.ThingDefs;

namespace ThingMan.Appl.Aggregates.Commands;

internal class CreateThingDefCommandHandler : IRequestHandler<CreateThingDefCommand, ThingDef>
{
    private readonly IMapper _mapper;
    private readonly IThingDefsRepository _thingDefsRepository;

    public CreateThingDefCommandHandler(
        IThingDefsRepository thingDefsRepository,
        IMapper mapper
    )
    {
        _thingDefsRepository = thingDefsRepository;
        _mapper = mapper;
    }

    public string Name => nameof(CreateThingDefCommandHandler);

    public async Task<ThingDef> Handle(CreateThingDefCommand request, CancellationToken cancellationToken)
    {
        var retval = ThingDef.Create(request.Name, request.UserId!, Array.Empty<StatusDef>());
        await _thingDefsRepository.CreateAsync(retval);
        return retval;
    }
}