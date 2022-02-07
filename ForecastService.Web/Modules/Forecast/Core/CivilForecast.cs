namespace ForecastService.Web.Modules.Forecast.Core;

public record CivilForecast : IForecast
{
    public int TimePoint { get; init; }

    public int CloudCover { get; init; }

    [JsonPropertyName("prec_type")]
    public string PrecType { get; init; }

    [JsonPropertyName("prec_amount")]
    public int PrecAmount { get; init; }

    public int Temp2m { get; init; }

    public string Rh2m { get; init; }

    public Wind Wind10m { get; init; }

    public string Weather { get; init; }
}