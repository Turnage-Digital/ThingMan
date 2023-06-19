using Microsoft.Extensions.DependencyInjection;
using ThingMan.Core.Configuration;

namespace ThingMan.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddAutoMapper(config => { config.AddProfile<CoreMappingProfile>(); });
        return services;
    }
}