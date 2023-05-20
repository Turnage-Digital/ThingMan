using AutoMapper;
using ThingMan.Domain.Dtos;

namespace ThingMan.Domain.Configuration;

public class DomainMappingProfile : Profile
{
    public DomainMappingProfile()
    {
        CreateMap<ThingDef, ThingDefDto>()
            .ReverseMap();

        CreateMap<StatusDef, StatusDefDto>()
            .ReverseMap();
        
        CreateMap<PropertyDef, PropertyDefDto>()
            .ReverseMap();
    }
}