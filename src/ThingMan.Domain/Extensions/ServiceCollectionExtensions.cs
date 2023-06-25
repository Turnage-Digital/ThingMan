using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using ThingMan.Core;

namespace ThingMan.Domain.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        var assembly = Assembly.GetAssembly(typeof(ServiceCollectionExtensions))!;
        services.AddMediatR(config =>
            config.RegisterServicesFromAssembly(assembly));
        services.AddScoped<IUserContext, UserContext>();
        return services;
    }

    public static IServiceCollection AddThingManAggregate<TThingDef>(this IServiceCollection services)
        where TThingDef : IWritableThingDef
    {
        services.AddSingleton<ThingDefAggregate<TThingDef>>();
        return services;
    }
}