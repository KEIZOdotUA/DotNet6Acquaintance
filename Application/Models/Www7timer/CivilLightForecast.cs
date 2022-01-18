using Newtonsoft.Json;

namespace Application.Models.Www7timer;

/// <summary>
/// 7Timer! CIVIL Light forecast model.
/// </summary>
/// <seealso cref="Application.Interfaces.IForecast" />
/// <seealso cref="System.IEquatable&lt;Application.Models.Www7timer.CivilLightForecast&gt;" />
public record CivilLightForecast : IForecast
{
    /// <summary>
    /// Forecast's date.
    /// </summary>
    public int Date { get; init; }

    /// <summary>
    /// Weather type.
    /// </summary>
    public string Weather { get; init; }

    /// <summary>
    /// Air temperature at 2 meters above the surface.
    /// </summary>
    public Temperature Temp2m { get; init; }

    /// <summary>
    /// The type of the wind.
    /// </summary>
    [JsonProperty("wind10m_max")]
    public int WindType { get; init; }
}
