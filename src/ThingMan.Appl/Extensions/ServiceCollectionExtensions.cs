namespace ThingMan.Appl.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAppl(this IServiceCollection services)
    {
        services.AddMediatR(config =>
            config.RegisterServicesFromAssemblyContaining(typeof(ServiceCollectionExtensions)));
        return services;
    }
}