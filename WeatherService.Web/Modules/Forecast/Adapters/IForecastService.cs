namespace WeatherService.Web.Modules.Forecast.Adapters;

/// <summary>
/// Forecast service interface.
/// </summary>
public interface IForecastService
{
    /// <summary>
    /// Gets the forecast asynchronous.
    /// </summary>
    /// <param name="lon">Geographic longitude.</param>
    /// <param name="lat">Geographic latitude.</param>
    /// <param name="product">Product type.</param>
    /// <returns>
    /// Forecast for location.
    /// </returns>
    Task<IEnumerable<IHumanizedForecast>> GetForecastAsync(float lon, float lat, Products product);
}
