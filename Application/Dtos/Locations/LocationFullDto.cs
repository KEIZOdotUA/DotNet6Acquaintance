namespace Application.Dtos.Locations;

/// <summary>
/// Location DTO.
/// </summary>
/// <seealso cref="System.IEquatable&lt;Application.Dtos.Locations.LocationFullDto&gt;" />
public record LocationFullDto
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

    /// <summary>
    /// Gets or sets the lon.
    /// </summary>
    /// <value>
    /// Geographic longitude coordinates.
    /// </value>
    public float Lon { get; set; }

    /// <summary>
    /// Gets or sets the lat.
    /// </summary>
    /// <value>
    /// Geographic latitude coordinates.
    /// </value>
    public float Lat { get; set; }
}
