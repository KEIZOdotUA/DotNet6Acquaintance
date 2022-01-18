using Newtonsoft.Json;

namespace Application.Models.Www7timer;

/// <summary>
/// The forecasted weather condition for the next 9-16 days.
/// </summary>
/// <seealso cref="Application.Interfaces.IForecast" />
/// <seealso cref="System.IEquatable&lt;Application.Models.Www7timer.TwoWeakForecast&gt;" />
public record TwoWeakForecast : IForecast
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
    /// Relative humidity at 2 meters above the surface.
    /// </summary>
    public int Rh2m { get; init; }

    /// <summary>
    /// Wind at 10 meters above the surface.
    /// </summary>
    public Wind Wind10m { get; init; }

    /// <summary>
    /// Weather type.
    /// </summary>
    public string Weather { get; init; }
}
