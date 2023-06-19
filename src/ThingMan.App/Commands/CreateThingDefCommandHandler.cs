using AutoMapper;
using MediatR;
using ThingMan.Core;
using ThingMan.Core.Entities;
using ThingMan.Core.Views;
using ThingMan.Domain;

namespace ThingMan.App.Commands;

public class CreateThingDefCommandHandler : IRequestHandler<CreateThingDefCommand, ThingDefView>
{
    private readonly IMapper _mapper;
    private readonly IThingManUnitOfWork _unitOfWork;

    public CreateThingDefCommandHandler(IThingManUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ThingDefView> Handle(CreateThingDefCommand request, CancellationToken cancellationToken)
    {
        var thingDef = request.ThingDef;
        var statusDefs = _mapper.Map<StatusDefView[], StatusDef[]>(thingDef.StatusDefs);
        var notificationDefs = _mapper.Map<NotificationDefView[], NotificationDef[]>(thingDef.NotificationDefs);

        PropertyDef? propertyDef1 = null;
        if (thingDef.PropertyDef1 is not null)
        {
            propertyDef1 = _mapper.Map<PropertyDefView, PropertyDef>(thingDef.PropertyDef1);
        }

        PropertyDef? propertyDef2 = null;
        if (thingDef.PropertyDef2 is not null)
        {
            propertyDef2 = _mapper.Map<PropertyDefView, PropertyDef>(thingDef.PropertyDef2);
        }

        PropertyDef? propertyDef3 = null;
        if (thingDef.PropertyDef3 is not null)
        {
            propertyDef3 = _mapper.Map<PropertyDefView, PropertyDef>(thingDef.PropertyDef3);
        }

        PropertyDef? propertyDef4 = null;
        if (thingDef.PropertyDef4 is not null)
        {
            propertyDef4 = _mapper.Map<PropertyDefView, PropertyDef>(thingDef.PropertyDef4);
        }

        PropertyDef? propertyDef5 = null;
        if (thingDef.PropertyDef5 is not null)
        {
            propertyDef5 = _mapper.Map<PropertyDefView, PropertyDef>(thingDef.PropertyDef5);
        }

        var created = ThingDefAggregate.Create(thingDef.Name, request.UserId!, statusDefs, notificationDefs,
            propertyDef1, propertyDef2, propertyDef3, propertyDef4, propertyDef5);

        await _unitOfWork.ThingDefsRepository.CreateAsync(created, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var retval = _mapper.Map<ThingDefView>(created);
        return retval;
    }
}