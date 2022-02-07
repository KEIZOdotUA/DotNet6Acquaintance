namespace ForecastService.Web.Modules.Forecast.Core;

public record Temperature
{
    public int Max { get; init; }

    public int Min { get; init; }
}
