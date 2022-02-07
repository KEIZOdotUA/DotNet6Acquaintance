namespace ForecastService.Web.Modules.Forecast.Core;

public record Www7timerResponse<T> where T : IForecast
{
    public string Product { get; init; }

    public string Init { get; init; }

    public T[] DataSeries { get; init; }
}
