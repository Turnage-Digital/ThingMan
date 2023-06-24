using System.Reflection;
using Lamar.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Serilog;
using ThingMan.App.Commands;
using ThingMan.Core.SqlDB;
using ThingMan.Core.SqlDB.Configuration;
using ThingMan.Core.SqlDB.Extensions;
using ThingMan.Domain;

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
            registry.AddSqlDB(connectionString);

            registry.AddSingleton(typeof(ThingDefAggregate<>));

            var appAssembly = Assembly.GetAssembly(typeof(CreateThingDefCommand))!;
            var domainAssembly = Assembly.GetAssembly(typeof(ThingDefAggregate<>))!;
            registry.AddMediatR(config =>
                config.RegisterServicesFromAssemblies(appAssembly, domainAssembly));

            registry
                .AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            registry.AddAutoMapper(config =>
                config.AddProfile<CoreMappingProfile>());

            registry
                .ConfigureApplicationCookie(options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.LogoutPath = "/Account/Logout";
                });

            registry.AddAuthorization();

            if (builder.Environment.IsDevelopment())
            {
                registry.AddEndpointsApiExplorer()
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

            SeedData.EnsureSeedData(app);
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

        app.MapThingDefsApi();
        app.MapUserApi();

        return app;
    }
}