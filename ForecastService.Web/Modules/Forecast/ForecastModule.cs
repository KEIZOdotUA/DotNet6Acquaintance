namespace ForecastService.Web.Modules.Forecast;

public static class ForecastModule
{
    public static void RegisterForecastServices(this IServiceCollection services)
    {
        services.AddTransient<IService, Service>();
    }

    public static void RegisterForecastEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/{type}", async (IService service, float lon, float lat, Products type) =>
        {
            var forecast = await service.GetForecastAsync(lon, lat, type);
            var result = Convert.ChangeType(forecast, forecast.GetType());
            return result;
        });
    }
}