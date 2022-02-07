namespace ForecastService.Web.Modules.Forecast.Core;

public record HumanizedCivilForecastDto : IHumanizedForecast
{
    public string DateTime { get; init; }

    public string CloudCover { get; init; }

    public string PrecType { get; init; }

    public string PrecAmount { get; init; }

    public string Temperature { get; init; }

    public string RelativeHumidity { get; init; }
}
