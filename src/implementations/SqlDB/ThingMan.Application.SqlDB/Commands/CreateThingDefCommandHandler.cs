using AutoMapper;
using ThingMan.Application.Commands;
using ThingMan.Core;
using ThingMan.Core.SqlDB.Entities;
using ThingMan.Core.SqlDB.Views;
using ThingMan.Domain;

namespace ThingMan.Application.SqlDB.Commands;

public class CreateThingDefCommandHandler : CreateThingDefCommandHandler<ThingDefView, ThingDefEntity>
{
    public CreateThingDefCommandHandler(
        ThingDefAggregate<ThingDefEntity> thingDefAggregate,
        IUnitOfWork unitOfWork,
        IMapper mapper
    ) : base(thingDefAggregate, unitOfWork, mapper) { }
}