namespace ForecastService.Web.Modules.Forecast.Adapters;

public interface IService
{
    Task<IEnumerable<IHumanizedForecast>> GetForecastAsync(float lon, float lat, Products type);
}
