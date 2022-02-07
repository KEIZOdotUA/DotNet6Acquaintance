namespace WeatherService.Web.Modules.Locations.Core;

/// <summary>
/// Geographic coordinates DTO.
/// </summary>
/// <seealso cref="System.IEquatable&lt;WeatherService.Web.Modules.Locations.Core.CoordinatesDto&gt;" />
public record CoordinatesDto
{
    /// <summary>
    /// Gets or sets the longitude.
    /// </summary>
    /// <value>
    /// The longitude.
    /// </value>
    public float Lon { get; set; }

    /// <summary>
    /// Gets or sets the latlatitude.
    /// </summary>
    /// <value>
    /// The latitude.
    /// </value>
    public float Lat { get; set; }
}
