namespace Application.Models.Www7timer;

/// <summary>
/// 7Timer! wind model.
/// </summary>
/// <seealso cref="System.IEquatable&lt;Application.Models.Www7timer.Wind&gt;" />
public record Wind
{
    /// <summary>
    /// Gets or sets the direction.
    /// </summary>
    /// <value>
    /// Wind direction.
    /// </value>
    public string Direction { get; init; }

    /// <summary>
    /// Gets or sets the speed.
    /// </summary>
    /// <value>
    /// Wind speed.
    /// </value>
    public int Speed { get; init; }
}
