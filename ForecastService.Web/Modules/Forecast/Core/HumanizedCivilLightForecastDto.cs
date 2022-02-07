namespace ForecastService.Web.Modules.Forecast.Core;

public record HumanizedCivilLightForecastDto : IHumanizedForecast
{
    public string Date { get; init; }

    public string Weather { get; init; }

    public string MinTemperature { get; init; }

    public string MaxTemperature { get; init; }

    public string Wind { get; init; }
}
