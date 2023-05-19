using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ThingMan.Domain;

namespace ThingMan.Infra.SqlDB.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddImplSqlDB(
        this IServiceCollection services,
        string connectionString
    )
    {
        services.AddDbContext<ThingManDbContext>(options =>
            options.UseSqlite(connectionString));

        services.AddRepositories();
        services.AddViews();

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IThingDefsRepository, ThingDefsRepository>();
        return services;
    }

    public static IServiceCollection AddViews(this IServiceCollection services)
    {
        services.AddScoped<IThingDefsView, ThingDefsView>();
        return services;
    }
}