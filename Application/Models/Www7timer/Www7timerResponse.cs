namespace Application.Models.Www7timer;

/// <summary>
/// 7Timer! response model.
/// </summary>
/// <typeparam name="T"></typeparam>
/// <seealso cref="System.IEquatable&lt;Application.Models.Www7timer.Www7timerResponse&lt;T&gt;&gt;" />
public record Www7timerResponse<T> where T : IForecast
{
    /// <summary>
    /// Gets or sets the product.
    /// </summary>
    /// <value>
    /// 7Timer! product type.
    /// </value>
    public string Product { get; init; }

    /// <summary>
    /// Gets or sets the initialization time.
    /// </summary>
    /// <value>
    /// Initialization time.
    /// </value>
    public string Init { get; init; }

    /// <summary>
    /// Gets or sets the data series.
    /// </summary>
    /// <value>
    /// Forecast.
    /// </value>
    public T[] DataSeries { get; init; }
}
