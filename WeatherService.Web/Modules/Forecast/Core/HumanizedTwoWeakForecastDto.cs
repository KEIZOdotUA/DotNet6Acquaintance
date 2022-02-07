namespace WeatherService.Web.Modules.Forecast.Core;

/// <summary>
/// Humanized version of 7timer! Two-Week-Overview forecast.
/// </summary>
/// <seealso cref="WeatherService.Web.Modules.Forecast.Core.IHumanizedForecast" />
/// <seealso cref="System.IEquatable&lt;WeatherService.Web.Modules.Forecast.Core.HumanizedTwoWeakForecastDto&gt;" />
public record HumanizedTwoWeakForecastDto : IHumanizedForecast
{
    /// <summary>
    /// Gets or sets the date time.
    /// </summary>
    /// <value>
    /// The date time.
    /// </value>
    public string DateTime { get; init; }

    /// <summary>
    /// Gets or sets the cloud cover.
    /// </summary>
    /// <value>
    /// The cloud cover.
    /// </value>
    public string CloudCover { get; init; }

    /// <summary>
    /// Gets or sets the relative humidity.
    /// </summary>
    /// <value>
    /// The relative humidity.
    /// </value>
    public string RelativeHumidity { get; init; }

    /// <summary>
    /// Gets or sets the wind direction.
    /// </summary>
    /// <value>
    /// The wind direction.
    /// </value>
    public string WindDirection { get; init; }

    /// <summary>
    /// Gets or sets the wind speed.
    /// </summary>
    /// <value>
    /// The wind speed.
    /// </value>
    public string WindSpeed { get; init; }

    /// <summary>
    /// Gets or sets the weather.
    /// </summary>
    /// <value>
    /// The weather short description.
    /// </value>
    public string Weather { get; init; }
}
