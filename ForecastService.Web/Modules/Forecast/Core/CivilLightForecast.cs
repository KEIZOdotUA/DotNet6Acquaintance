namespace ForecastService.Web.Modules.Forecast.Core;

public record CivilLightForecast : IForecast
{
    public int Date { get; init; }

    public string Weather { get; init; }

    public Temperature Temp2m { get; init; }

    [JsonPropertyName("wind10m_max")]
    public int WindType { get; init; }
}
