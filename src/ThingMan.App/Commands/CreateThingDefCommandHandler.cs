using AutoMapper;
using MediatR;
using ThingMan.Core;
using ThingMan.Domain;

namespace ThingMan.App.Commands;

public class CreateThingDefCommandHandler : IRequestHandler<CreateThingDefCommand, IReadOnlyThingDef>
{
    private readonly IMapper _mapper;
    private readonly ThingDefAggregate<IWritableThingDef> _thingDefAggregate;
    private readonly IUnitOfWork _unitOfWork;

    public CreateThingDefCommandHandler(
        ThingDefAggregate<IWritableThingDef> thingDefAggregate,
        IUnitOfWork unitOfWork,
        IMapper mapper
    )
    {
        _thingDefAggregate = thingDefAggregate;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IReadOnlyThingDef> Handle(
        CreateThingDefCommand request,
        CancellationToken cancellationToken = default
    )
    {
        var created = await _thingDefAggregate.CreateAsync(
            request.Name,
            request.StatusDefs,
            request.PropertyDef1,
            request.PropertyDef2,
            request.PropertyDef3,
            request.PropertyDef4,
            request.PropertyDef5,
            cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        var retval = _mapper.Map<IReadOnlyThingDef>(created);
        return retval;
    }
}