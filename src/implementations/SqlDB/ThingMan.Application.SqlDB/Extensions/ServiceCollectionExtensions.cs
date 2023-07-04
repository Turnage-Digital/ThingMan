using System.Reflection;

namespace ThingMan.Application.SqlDB.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationSqlDB(this IServiceCollection services)
    {
        var assembly = Assembly.GetAssembly(typeof(ServiceCollectionExtensions))!;
        services.AddMediatR(config =>
            config.RegisterServicesFromAssembly(assembly));
        return services;
    }
}