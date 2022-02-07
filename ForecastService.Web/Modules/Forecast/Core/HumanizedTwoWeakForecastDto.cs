namespace ForecastService.Web.Modules.Forecast.Core;

public record HumanizedTwoWeakForecastDto : IHumanizedForecast
{
    public string DateTime { get; init; }

    public string CloudCover { get; init; }

    public string RelativeHumidity { get; init; }

    public string WindDirection { get; init; }

    public string WindSpeed { get; init; }

    public string Weather { get; init; }
}
