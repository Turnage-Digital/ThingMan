using MediatR;
using ThingMan.Core;

namespace ThingMan.App.Commands;

public class CreateThingDefCommandHandler<TKey> : IRequestHandler<CreateThingDefCommand<TKey>, IThingDef<TKey>>
{
    // private readonly IMapper _mapper;
    // private readonly IThingManUnitOfWork _unitOfWork;

    // public CreateThingDefCommandHandler(IThingManUnitOfWork unitOfWork, IMapper mapper)
    // {
    //     _unitOfWork = unitOfWork;
    //     _mapper = mapper;
    // }

    // public async Task<ThingDefView> Handle(CreateThingDefCommand request, CancellationToken cancellationToken)
    // {
    //     throw new NotImplementedException();
    //     // var thingDef = request.ThingDef;
    //     // var statusDefs = _mapper.Map<StatusDefDto[], StatusDef[]>(thingDef.StatusDefs);
    //     // var notificationDefs = _mapper.Map<NotificationDefDto[], NotificationDef[]>(thingDef.NotificationDefs);
    //     //
    //     // PropertyDef? propertyDef1 = null;
    //     // if (thingDef.PropertyDef1 is not null)
    //     // {
    //     //     propertyDef1 = _mapper.Map<PropertyDefDto, PropertyDef>(thingDef.PropertyDef1);
    //     // }
    //     //
    //     // PropertyDef? propertyDef2 = null;
    //     // if (thingDef.PropertyDef2 is not null)
    //     // {
    //     //     propertyDef2 = _mapper.Map<PropertyDefDto, PropertyDef>(thingDef.PropertyDef2);
    //     // }
    //     //
    //     // PropertyDef? propertyDef3 = null;
    //     // if (thingDef.PropertyDef3 is not null)
    //     // {
    //     //     propertyDef3 = _mapper.Map<PropertyDefDto, PropertyDef>(thingDef.PropertyDef3);
    //     // }
    //     //
    //     // PropertyDef? propertyDef4 = null;
    //     // if (thingDef.PropertyDef4 is not null)
    //     // {
    //     //     propertyDef4 = _mapper.Map<PropertyDefDto, PropertyDef>(thingDef.PropertyDef4);
    //     // }
    //     //
    //     // PropertyDef? propertyDef5 = null;
    //     // if (thingDef.PropertyDef5 is not null)
    //     // {
    //     //     propertyDef5 = _mapper.Map<PropertyDefDto, PropertyDef>(thingDef.PropertyDef5);
    //     // }
    //     //
    //     // var created = ThingDefAggregate.Create(thingDef.Name, request.UserId!, statusDefs, notificationDefs,
    //     //     propertyDef1, propertyDef2, propertyDef3, propertyDef4, propertyDef5);
    //     //
    //     // await _unitOfWork.ThingDefsStore.CreateAsync(created, cancellationToken);
    //     // await _unitOfWork.SaveChangesAsync(cancellationToken);
    //     //
    //     // var retval = _mapper.Map<ThingDefDto>(created);
    //     // return retval;
    // }

    public async Task<IThingDef<TKey>> Handle(CreateThingDefCommand<TKey> request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}