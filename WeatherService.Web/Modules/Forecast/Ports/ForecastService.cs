using Microsoft.AspNetCore.WebUtilities;

namespace WeatherService.Web.Modules.Forecast.Ports;

/// <summary>
/// Forecast service interface implementation.
/// </summary>
/// <seealso cref="WeatherService.Web.Modules.Forecast.Adapters.IForecastService" />
public class ForecastService : IForecastService
{
    private readonly IHttpClientFactory _httpClientFactory;

    /// <summary>
    /// Initializes a new instance of the <see cref="ForecastService"/> class.
    /// </summary>
    /// <param name="httpClientFactory">The HTTP client factory.</param>
    public ForecastService(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

    /// <summary>
    /// Gets the forecast asynchronous.
    /// </summary>
    /// <param name="lon">Geographic longitude.</param>
    /// <param name="lat">Geographic latitude.</param>
    /// <param name="product">Product type.</param>
    /// <returns>
    /// Forecast for location.
    /// </returns>
    /// <exception cref="System.ArgumentException"></exception>
    public async Task<IEnumerable<IHumanizedForecast>> GetForecastAsync(float lon, float lat, Products product)
    {
        var client = _httpClientFactory.CreateClient(Services.Forecast.ToString());
        var queryString = new Dictionary<string, string>()
        {
            { nameof(lon), lon.ToString() },
            { nameof(lat), lat.ToString() },
        };
        var requestUri = QueryHelpers.AddQueryString(product.ToString(), queryString);
        var request = new HttpRequestMessage(HttpMethod.Get, requestUri);

        var response = await client.SendAsync(request);
        var content = await response.ProcessResponse();

        return product switch
        {
            Products.Civil => JsonConvert.DeserializeObject<HumanizedCivilForecastDto[]>(content),
            Products.Civillight => JsonConvert.DeserializeObject<HumanizedCivilLightForecastDto[]>(content),
            Products.Two => JsonConvert.DeserializeObject<HumanizedTwoWeakForecastDto[]>(content),
            _ => throw new ArgumentException(),
        };
    }
}