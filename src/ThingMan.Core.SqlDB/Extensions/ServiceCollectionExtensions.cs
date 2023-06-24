using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ThingMan.Core.SqlDB.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSqlDB(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connectionString));
        services.AddDbContext<ThingManDbContext>(options => options.UseSqlite(connectionString));

        services.AddScoped<IUnitOfWork, UnitOfWork<ThingManDbContext>>();

        services.AddRepositories();
        services.AddViews();

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IThingDefsStore<IWritableThingDef>, ThingDefsStore>();
        return services;
    }

    public static IServiceCollection AddViews(this IServiceCollection services)
    {
        services.AddScoped<IGetThingDefViewById, GetThingDefViewById>();
        return services;
    }
}