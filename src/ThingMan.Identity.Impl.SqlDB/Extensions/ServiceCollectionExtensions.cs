using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ThingMan.Identity.Impl.SqlDB.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddIdentityImplSqlDB(
        this IServiceCollection services,
        string connectionString
    )
    {
        var migrationAssemblyName = typeof(ApplicationDbContext).Assembly.FullName!;

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(connectionString, optionsBuilder =>
                optionsBuilder.MigrationsAssembly(migrationAssemblyName)));

        return services;
    }
}