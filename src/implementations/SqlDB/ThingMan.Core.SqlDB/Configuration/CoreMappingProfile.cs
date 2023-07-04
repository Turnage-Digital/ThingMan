using AutoMapper;
using ThingMan.Core.SqlDB.Entities;
using ThingMan.Core.SqlDB.Views;
using ThingMan.Core.ValueObjects;

namespace ThingMan.Core.SqlDB.Configuration;

public class CoreMappingProfile : Profile
{
    public CoreMappingProfile()
    {
        CreateMap<ThingDefEntity, ThingDefView>();

        CreateMap<ThingDefEntity, IReadOnlyThingDef>()
            .As<ThingDefView>();

        CreateMap<StatusDefEntity, StatusDef>();
        CreateMap<PropertyDefEntity, PropertyDef>();
    }
}