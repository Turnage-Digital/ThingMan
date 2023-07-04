using AutoMapper;
using MediatR;
using ThingMan.Core;
using ThingMan.Domain;

namespace ThingMan.Application.Commands;

public class CreateThingDefCommandHandler<TReadOnlyThingDef, TWritableThingDef>
    : IRequestHandler<CreateThingDefCommand<TReadOnlyThingDef>, TReadOnlyThingDef>
    where TReadOnlyThingDef : IReadOnlyThingDef
    where TWritableThingDef : IWritableThingDef
{
    private readonly IMapper _mapper;
    private readonly ThingDefAggregate<TWritableThingDef> _thingDefAggregate;
    private readonly IUnitOfWork _unitOfWork;

    protected CreateThingDefCommandHandler(
        ThingDefAggregate<TWritableThingDef> thingDefAggregate,
        IUnitOfWork unitOfWork,
        IMapper mapper
    )
    {
        _thingDefAggregate = thingDefAggregate;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<TReadOnlyThingDef> Handle(
        CreateThingDefCommand<TReadOnlyThingDef> request,
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
        var retval = _mapper.Map<TReadOnlyThingDef>(created);
        return retval;
    }
}