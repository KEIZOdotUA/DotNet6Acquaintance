namespace WeatherService.Web.Modules.Locations.Core;

/// <summary>
/// Location short info DTO
/// </summary>
/// <seealso cref="System.IEquatable&lt;WeatherService.Web.Modules.Locations.Core.LocationShortDto&gt;" />
public record LocationShortDto
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>
    /// The identifier.
    /// </value>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets location name.
    /// </summary>
    /// <value>
    /// The name.
    /// </value>
    public string Name { get; set; }
}
