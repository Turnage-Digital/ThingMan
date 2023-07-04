namespace ThingMan.Application.SqlDB.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UseApp(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            SeedData.EnsureSeedData(app);
        }

        app.MapThingDefsApi();
        app.MapUserApi();
        return app;
    }
}