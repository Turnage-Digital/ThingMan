using AutoMapper;
using MediatR;
using ThingMan.Domain;
using ThingMan.Domain.Dtos;

namespace ThingMan.App.Commands;

public class CreateThingDefCommandHandler : IRequestHandler<CreateThingDefCommand, ThingDef>
{
    private readonly IMapper _mapper;
    private readonly IThingDefsRepository _thingDefsRepository;

    public CreateThingDefCommandHandler(IThingDefsRepository thingDefsRepository, IMapper mapper)
    {
        _thingDefsRepository = thingDefsRepository;
        _mapper = mapper;
    }

    public string Name => nameof(CreateThingDefCommandHandler);

    public async Task<ThingDef> Handle(CreateThingDefCommand request, CancellationToken cancellationToken)
    {
        var statusDefs = _mapper.Map<StatusDefDto[], StatusDef[]>(request.StatusDefs);
        var notificationDefs = _mapper.Map<NotificationDefDto[], NotificationDef[]>(request.NotificationDefs);

        PropertyDef? propertyDef1 = null;
        if (request.PropertyDef1 is not null)
        {
            propertyDef1 = _mapper.Map<PropertyDefDto, PropertyDef>(request.PropertyDef1);
        }

        PropertyDef? propertyDef2 = null;
        if (request.PropertyDef2 is not null)
        {
            propertyDef2 = _mapper.Map<PropertyDefDto, PropertyDef>(request.PropertyDef2);
        }

        PropertyDef? propertyDef3 = null;
        if (request.PropertyDef3 is not null)
        {
            propertyDef3 = _mapper.Map<PropertyDefDto, PropertyDef>(request.PropertyDef3);
        }

        var retval = ThingDef.Create(request.Name, request.UserId!, statusDefs, notificationDefs,
            propertyDef1, propertyDef2, propertyDef3);
        await _thingDefsRepository.CreateAsync(retval);
        return retval;
    }
}