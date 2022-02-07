namespace WeatherService.Web.Modules.Forecast.Core;

/// <summary>
/// Humanized version of 7timer! CIVIL forecast.
/// </summary>
/// <seealso cref="WeatherService.Web.Modules.Forecast.Core.IHumanizedForecast" />
/// <seealso cref="System.IEquatable&lt;WeatherService.Web.Modules.Forecast.Core.HumanizedCivilForecastDto&gt;" />
public record HumanizedCivilForecastDto : IHumanizedForecast
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
    /// Gets or sets the type of the prec.
    /// </summary>
    /// <value>
    /// The type of the precipitation.
    /// </value>
    public string PrecType { get; init; }

    /// <summary>
    /// Gets or sets the prec amount.
    /// </summary>
    /// <value>
    /// The precipitation amount.
    /// </value>
    public string PrecAmount { get; init; }

    /// <summary>
    /// Gets or sets the temperature.
    /// </summary>
    /// <value>
    /// The temperature.
    /// </value>
    public string Temperature { get; init; }

    /// <summary>
    /// Gets or sets the relative humidity.
    /// </summary>
    /// <value>
    /// The relative humidity.
    /// </value>
    public string RelativeHumidity { get; init; }
}
