using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ThingMan.Core.SqlDB.Configuration;
using ThingMan.Core.SqlDB.Entities;
using ThingMan.Core.SqlDB.Views;

namespace ThingMan.Core.SqlDB.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCoreSqlDB(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connectionString));
        services.AddDbContext<ThingManDbContext>(options => options.UseSqlite(connectionString));

        services.AddScoped<IUnitOfWork, UnitOfWork<ThingManDbContext>>();

        services.AddRepositories();
        services.AddViews();

        services.AddAutoMapper(config =>
            config.AddProfile<CoreMappingProfile>());

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IThingDefsStore<ThingDefEntity>, ThingDefsStore>();
        return services;
    }

    public static IServiceCollection AddViews(this IServiceCollection services)
    {
        services.AddScoped<IGetReadOnlyThingDefById<ThingDefView>, GetReadOnlyThingDefById>();
        return services;
    }
}