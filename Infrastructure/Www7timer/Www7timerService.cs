using Application.Interfaces.Services;
using Domain.Enums.Www7timer;
using RestSharp;

namespace Infrastructure.Www7timer;

/// <summary>
/// 7Timer! service interface implementation.
/// </summary>
/// <seealso cref="Application.Interfaces.Services.IWww7timerService" />
public class Www7timerService : IWww7timerService
{
    /// <summary>
    /// Weather API host.
    /// </summary>
    private const string _host = "https://www.7timer.info";

    /// <summary>
    /// Weather API path.
    /// </summary>
    private const string _apiPath = "bin/api.pl";

    /// <summary>
    /// 7Timer! response type parameter.
    /// </summary>
    public const string _outputParameter = "output";

    /// <summary>
    /// 7Timer! units parameter.
    /// </summary>
    public const string _unitParameter = "unit";

    /// <summary>
    /// API request default parameters.
    /// </summary>
    public static readonly Dictionary<string, string> _defaultParameters = new()
    {
        { _outputParameter, ResponseTypes.Json.ToString().ToLower() },
        { _unitParameter, Units.Metric.ToString().ToLower() },
    };

    /// <summary>
    /// Gets weather forecast asynchronous.
    /// </summary>
    /// <param name="lon">Longitude.</param>
    /// <param name="lat">Latitude.</param>
    /// <param name="product">7Timer! product type.</param>
    /// <returns>
    /// Weather forecast.
    /// </returns>
    public async Task<RestResponse> GetForecastAsync(float lon, float lat, Products product)
    {
        var client = new RestClient(_host);

        var request = new RestRequest(_apiPath, Method.Get);
        request.AddParameter(nameof(lon), lon);
        request.AddParameter(nameof(lat), lat);
        request.AddParameter(nameof(product), product.ToString().ToLower());
        request.AddParameter(_outputParameter, _defaultParameters[_outputParameter]);
        request.AddParameter(_unitParameter, _defaultParameters[_unitParameter]);

        var retValue = await client.ExecuteAsync(request);

        return retValue;
    }
}
