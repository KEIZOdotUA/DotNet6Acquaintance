namespace WeatherService.Web.Extensions;

/// <summary>
/// Register application services extension.
/// </summary>
public static class RegisterServicesExtension
{
    /// <summary>
    /// Registers application services.
    /// </summary>
    /// <param name="services">Application services instance.</param>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddMvc(options => { options.Filters.Add(typeof(HttpGlobalExceptionFilter)); });

        services.AddTransient<ILocationsService, LocationsService>();
        services.AddTransient<IForecastService, ForecastService>();

        services.AddMediatR(typeof(Program));
    }
}
