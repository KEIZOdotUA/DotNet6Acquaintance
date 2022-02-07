namespace ForecastService.Web.Modules.Forecast.Core;

public record TwoWeakForecast : IForecast
{
    public int TimePoint { get; init; }

    public int CloudCover { get; init; }

    public int Rh2m { get; init; }

    public Wind Wind10m { get; init; }

    public string Weather { get; init; }
}
