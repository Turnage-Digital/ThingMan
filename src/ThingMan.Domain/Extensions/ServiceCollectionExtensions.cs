using Microsoft.Extensions.DependencyInjection;

namespace ThingMan.Domain.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddMediatR(config =>
            config.RegisterServicesFromAssemblyContaining(typeof(ServiceCollectionExtensions)));
        return services;
    }
}