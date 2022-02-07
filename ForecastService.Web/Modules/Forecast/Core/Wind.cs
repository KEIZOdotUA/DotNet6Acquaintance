namespace ForecastService.Web.Modules.Forecast.Core;

public record Wind
{
    public string Direction { get; init; }

    public int Speed { get; init; }
}
