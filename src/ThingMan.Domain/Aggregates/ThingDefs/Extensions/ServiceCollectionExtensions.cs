using Microsoft.Extensions.DependencyInjection;
using ThingMan.Core.Events;
using ThingMan.Domain.Aggregates.ThingDefs.Events;

namespace ThingMan.Domain.Aggregates.ThingDefs.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddThingDefs(this IServiceCollection services)
    {
        services.AddEventHandlers();
        
        return services;
    }

    public static IServiceCollection AddEventHandlers(this IServiceCollection services)
    {
        services.AddScoped<IHandleEvent<ThingDefCreatedEvent>,
            ThingDefCreatedEventHandler>();
        return services;
    }
}