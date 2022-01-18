namespace Application.Dtos.Weather;

/// <summary>
/// Humanized version of 7timer! CIVIL Light forecast.
/// </summary>
/// <seealso cref="Application.Interfaces.IHumanizedForecast" />
/// <seealso cref="System.IEquatable&lt;Application.Dtos.Weather.HumanizedCivilLightForecastDto&gt;" />
public record HumanizedCivilLightForecastDto : IHumanizedForecast
{
    /// <summary>
    /// Gets or sets the date.
    /// </summary>
    /// <value>
    /// The date.
    /// </value>
    public string Date { get; init; }

    /// <summary>
    /// Gets or sets the weather.
    /// </summary>
    /// <value>
    /// The weather short description.
    /// </value>
    public string Weather { get; init; }

    /// <summary>
    /// Gets or sets the minimum temperature.
    /// </summary>
    /// <value>
    /// The minimum temperature.
    /// </value>
    public string MinTemperature { get; init; }

    /// <summary>
    /// Gets or sets the maximum temperature.
    /// </summary>
    /// <value>
    /// The maximum temperature.
    /// </value>
    public string MaxTemperature { get; init; }

    /// <summary>
    /// Gets or sets the wind.
    /// </summary>
    /// <value>
    /// The wind speed.
    /// </value>
    public string Wind { get; init; }
}
