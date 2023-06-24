using AutoMapper;
using ThingMan.Core.SqlDB.Entities;
using ThingMan.Core.SqlDB.Views;

namespace ThingMan.Core.SqlDB.Configuration;

public class CoreMappingProfile : Profile
{
    public CoreMappingProfile()
    {
        CreateMap<ThingDefView, ThingDefEntity>()
            .ReverseMap();
        CreateMap<ThingDefView, IWritableThingDef>()
            .As<ThingDefEntity>();
        CreateMap<ThingDefEntity, IReadOnlyThingDef>()
            .As<ThingDefView>();
        CreateMap<StatusDefView, StatusDefEntity>()
            .ReverseMap();
        CreateMap<NotificationDefView, NotificationDefEntity>()
            .ReverseMap();
        CreateMap<PropertyDefView, PropertyDefEntity>()
            .ReverseMap();
    }
}