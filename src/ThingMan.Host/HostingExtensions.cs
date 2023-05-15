using Microsoft.OpenApi.Models;
using Serilog;
using ThingMan.Appl.Extensions;
using ThingMan.Domain.Extensions;
using ThingMan.Identity.Impl.SqlDB.Extensions;
using ThingMan.Impl.SqlDB.Extensions;

namespace ThingMan.Host;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
        builder.Services.AddImplSqlDB(connectionString);
        builder.Services.AddIdentityImplSqlDB(connectionString);

        builder.Services.AddDomain();
        builder.Services.AddAppl();

        builder.Services.AddAuthorization();

        if (builder.Environment.IsDevelopment())
        {
            builder.Services.AddEndpointsApiExplorer()
                .AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "ThingMan"
                    });
                });
        }

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
        }

        app.UseHsts();
        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseRouting();

        app.UseAuthorization();

        app.MapThingDefsApi();
        app.MapUserApi();

        return app;
    }
}