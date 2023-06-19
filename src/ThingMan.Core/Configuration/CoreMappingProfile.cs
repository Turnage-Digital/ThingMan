using AutoMapper;
using ThingMan.Core.Entities;
using ThingMan.Core.Views;

namespace ThingMan.Core.Configuration;

public class CoreMappingProfile : Profile
{
    public CoreMappingProfile()
    {
        CreateMap<ThingDef, ThingDefView>()
            .ReverseMap();

        CreateMap<StatusDef, StatusDefView>()
            .ReverseMap();

        CreateMap<NotificationDef, NotificationDefView>()
            .ReverseMap();

        CreateMap<PropertyDef, PropertyDefView>()
            .ReverseMap();
    }
}