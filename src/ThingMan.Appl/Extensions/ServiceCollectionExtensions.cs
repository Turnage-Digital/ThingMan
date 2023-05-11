using ThingMan.Appl.Aggregates.Commands;
using ThingMan.Appl.Aggregates.Queries;
using ThingMan.Core.Commands;
using ThingMan.Core.Queries;
using ThingMan.Domain.Aggregates.ThingDefs;
using ThingMan.Domain.Aggregates.ThingDefs.Dtos;

namespace ThingMan.Appl.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddThingDefs(this IServiceCollection services)
    {
        services.AddCommandHandlers();
        services.AddQueryAwaiters();
        return services;
    }

    public static IServiceCollection AddCommandHandlers(this IServiceCollection services)
    {
        services.AddScoped<IHandleCommand<CreateThingDefCommand, ThingDef>,
            CreateThingDefCommandHandler>();
        return services;
    }

    public static IServiceCollection AddQueryAwaiters(this IServiceCollection services)
    {
        services.AddScoped<IAwaitQuery<GetThingDefByIdQuery, ThingDefDto>,
            GetThingDefByIdQueryAwaiter>();
        return services;
    }
}