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

    public async Task<IReadOnlyThingDef> Handle(CreateThingDefCommand request, CancellationToken cancellationToken)
    {
        var readOnly = request.ThingDef;
        var writable = _mapper.Map<IWritableThingDef>(readOnly);

        var created = _thingDefAggregate.CreateAsync(writable, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var retval = _mapper.Map<IReadOnlyThingDef>(created);
        return retval;
    }
}