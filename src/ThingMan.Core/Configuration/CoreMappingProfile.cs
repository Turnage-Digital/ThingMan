using AutoMapper;
using ThingMan.Contracts.Dtos;
using ThingMan.Core.Entities;

namespace ThingMan.Core.Configuration;

public class CoreMappingProfile : Profile
{
    public CoreMappingProfile()
    {
        CreateMap<ThingDef, ThingDefDto>()
            .ReverseMap();

        CreateMap<StatusDef, StatusDefDto>()
            .ReverseMap();

        CreateMap<NotificationDef, NotificationDefDto>()
            .ReverseMap();

        CreateMap<PropertyDef, PropertyDefDto>()
            .ReverseMap();
    }
}