using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using ThingMan.Core.SqlDB.Entities;

namespace ThingMan.Domain.SqlDB.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomainSqlDB(this IServiceCollection services)
    {
        var assembly = Assembly.GetAssembly(typeof(ServiceCollectionExtensions))!;
        services.AddMediatR(config =>
            config.RegisterServicesFromAssembly(assembly));
        services.AddSingleton<ThingDefAggregate<ThingDefEntity>>();
        return services;
    }
}