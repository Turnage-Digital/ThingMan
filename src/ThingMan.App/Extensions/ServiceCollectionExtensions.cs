using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace ThingMan.App.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApp(this IServiceCollection services)
    {
        var assembly = Assembly.GetAssembly(typeof(ServiceCollectionExtensions))!;
        services.AddMediatR(config =>
            config.RegisterServicesFromAssembly(assembly));
        return services;
    }
}