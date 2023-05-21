using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ThingMan.Domain;
using ThingMan.Infra.SqlDB.Repositories;
using ThingMan.Infra.SqlDB.Views;

namespace ThingMan.Infra.SqlDB.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSqlDB(
        this IServiceCollection services,
        string connectionString
    )
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(connectionString));

        services.AddDbContext<ThingManDbContext>(options =>
            options.UseSqlite(connectionString));
        
        services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

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