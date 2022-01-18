namespace Application.Models.Www7timer;

/// <summary>
/// 7Timer! temperature model.
/// </summary>
/// <seealso cref="System.IEquatable&lt;Application.Models.Www7timer.Temperature&gt;" />
public record Temperature
{
    /// <summary>
    /// Maximum temperature.
    /// </summary>
    public int Max { get; init; }

    /// <summary>
    /// Minimum temperature.
    /// </summary>
    public int Min { get; init; }
}
