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
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(connectionString));

        return services;
    }
}