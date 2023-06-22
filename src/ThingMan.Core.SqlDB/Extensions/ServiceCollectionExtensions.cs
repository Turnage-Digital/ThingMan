using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ThingMan.Core.SqlDB.Configuration;
using ThingMan.Core.SqlDB.Entities;

namespace ThingMan.Core.SqlDB.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSqlDB(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(connectionString));

        services.AddDbContext<ThingManDbContext>(options =>
            options.UseSqlite(connectionString));

        services.AddScoped<IThingManUnitOfWork<ThingDefEntity, Guid>, ThingManUnitOfWork>();

        services.AddRepositories();
        services.AddViews();

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IThingDefsStore<ThingDefEntity, Guid>, ThingDefsStore>();
        return services;
    }

    public static IServiceCollection AddViews(this IServiceCollection services)
    {
        services.AddScoped<IGetThingDefViewById<Guid>, GetThingDefViewById>();
        return services;
    }
}