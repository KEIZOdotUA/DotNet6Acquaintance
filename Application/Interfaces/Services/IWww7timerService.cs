using Domain.Enums.Www7timer;
using RestSharp;

namespace Application.Interfaces.Services;

/// <summary>
/// 7Timer! service interface.
/// </summary>
public interface IWww7timerService
{
    /// <summary>
    /// Gets weather forecast asynchronous.
    /// </summary>
    /// <param name="lon">Longitude.</param>
    /// <param name="lat">Latitude.</param>
    /// <param name="product">7Timer! product type.</param>
    /// <returns>
    /// Weather forecast.
    /// </returns>
    public Task<RestResponse> GetForecastAsync(float lon, float lat, Products product);
}
