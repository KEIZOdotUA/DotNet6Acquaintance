using Newtonsoft.Json;

namespace Application.Models.Www7timer;

/// <summary>
/// 7Timer! CIVIL forecast model.
/// </summary>
/// <seealso cref="Application.Interfaces.IForecast" />
/// <seealso cref="System.IEquatable&lt;Application.Models.Www7timer.CivilForecast&gt;" />
public record CivilForecast : IForecast
{
    /// <summary>
    /// Offset from init time.
    /// </summary>
    public int TimePoint { get; init; }

    /// <summary>
    /// Cloud cover type.
    /// </summary>
    public int CloudCover { get; init; }

    /// <summary>
    /// Precipitation type.
    /// </summary>
    [JsonProperty("prec_type")]
    public string PrecType { get; init; }

    /// <summary>
    /// Precipitation amount.
    /// </summary>
    [JsonProperty("prec_amount")]
    public int PrecAmount { get; init; }

    /// <summary>
    /// Air temperature at 2 meters above the surface.
    /// </summary>
    public int Temp2m { get; init; }

    /// <summary>
    /// Relative humidity at 2 meters above the surface.
    /// </summary>
    public string Rh2m { get; init; }

    /// <summary>
    /// Wind at 10 meters above the surface.
    /// </summary>
    public Wind Wind10m { get; init; }

    /// <summary>
    /// Weather type.
    /// </summary>
    public string Weather { get; init; }
}