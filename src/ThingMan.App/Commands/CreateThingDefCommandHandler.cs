using AutoMapper;
using MediatR;
using ThingMan.Domain;
using ThingMan.Domain.Dtos;

namespace ThingMan.App.Commands;

public class CreateThingDefCommandHandler : IRequestHandler<CreateThingDefCommand, ThingDef>
{
    private readonly IMapper _mapper;
    private readonly IThingManUnitOfWork _unitOfWork;

    public CreateThingDefCommandHandler(IThingManUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ThingDef> Handle(CreateThingDefCommand request, CancellationToken cancellationToken)
    {
        var thingDefDto = request.ThingDef;
        var statusDefs = _mapper.Map<StatusDefDto[], StatusDef[]>(thingDefDto.StatusDefs);
        var notificationDefs = _mapper.Map<NotificationDefDto[], NotificationDef[]>(thingDefDto.NotificationDefs);

        PropertyDef? propertyDef1 = null;
        if (thingDefDto.PropertyDef1 is not null)
        {
            propertyDef1 = _mapper.Map<PropertyDefDto, PropertyDef>(thingDefDto.PropertyDef1);
        }

        PropertyDef? propertyDef2 = null;
        if (thingDefDto.PropertyDef2 is not null)
        {
            propertyDef2 = _mapper.Map<PropertyDefDto, PropertyDef>(thingDefDto.PropertyDef2);
        }

        PropertyDef? propertyDef3 = null;
        if (thingDefDto.PropertyDef3 is not null)
        {
            propertyDef3 = _mapper.Map<PropertyDefDto, PropertyDef>(thingDefDto.PropertyDef3);
        }

        PropertyDef? propertyDef4 = null;
        if (thingDefDto.PropertyDef4 is not null)
        {
            propertyDef4 = _mapper.Map<PropertyDefDto, PropertyDef>(thingDefDto.PropertyDef4);
        }

        PropertyDef? propertyDef5 = null;
        if (thingDefDto.PropertyDef5 is not null)
        {
            propertyDef5 = _mapper.Map<PropertyDefDto, PropertyDef>(thingDefDto.PropertyDef5);
        }

        var retval = ThingDef.Create(thingDefDto.Name, request.UserId!, statusDefs, notificationDefs,
            propertyDef1, propertyDef2, propertyDef3, propertyDef4, propertyDef5);

        await _unitOfWork.ThingDefsRepository.CreateAsync(retval, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return retval;
    }
}