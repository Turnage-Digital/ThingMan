using Lamar.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Serilog;
using ThingMan.Application.SqlDB.Extensions;
using ThingMan.Core.SqlDB;
using ThingMan.Core.SqlDB.Extensions;
using ThingMan.Domain.SqlDB.Extensions;

namespace ThingMan;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((context, config) => config
            .WriteTo.Console(outputTemplate:
                "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
            .Enrich.FromLogContext()
            .ReadFrom.Configuration(context.Configuration));

        builder.Host.UseLamar(registry =>
        {
            var connectionString = builder.Configuration
                .GetConnectionString("DefaultConnection")!;
            registry.AddCoreSqlDB(connectionString);
            registry.AddDomainSqlDB();
            registry.AddApplicationSqlDB();

            registry
                .AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            registry
                .ConfigureApplicationCookie(options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.LogoutPath = "/Account/Logout";
                });

            registry.AddAuthorization();

            if (builder.Environment.IsDevelopment())
            {
                registry
                    .AddEndpointsApiExplorer()
                    .AddSwaggerGen(options =>
                    {
                        options.SwaggerDoc("v1", new OpenApiInfo
                        {
                            Version = "v1",
                            Title = "ThingMan"
                        });
                    });
            }
        });

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseSerilogRequestLogging();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        else
        {
            app.UseExceptionHandler();
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseApp();

        return app;
    }
}