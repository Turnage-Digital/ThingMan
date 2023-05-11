namespace ThingMan.App.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UseApp(this WebApplication app)
    {
        app.MapThingDefsApi();
        app.MapUserApi();
        return app;
    }
}