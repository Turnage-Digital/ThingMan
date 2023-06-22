using AutoMapper;
using ThingMan.Core.SqlDB.Entities;
using ThingMan.Core.SqlDB.Views;

namespace ThingMan.Core.SqlDB.Configuration;

public class CoreMappingProfile : Profile
{
    public CoreMappingProfile()
    {
        CreateMap<ThingDefEntity, ThingDefView<Guid>>()
            .ReverseMap();

        CreateMap<StatusDefEntity, StatusDefView>()
            .ReverseMap();

        CreateMap<NotificationDefEntity, NotificationDefView>()
            .ReverseMap();

        CreateMap<PropertyDefEntity, PropertyDefView>()
            .ReverseMap();
    }
}