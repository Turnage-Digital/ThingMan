using Microsoft.Extensions.DependencyInjection;

namespace ThingMan.App.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApp(this IServiceCollection services)
    {
        services.AddMediatR(config =>
            config.RegisterServicesFromAssemblyContaining(typeof(ServiceCollectionExtensions)));
        return services;
    }
}