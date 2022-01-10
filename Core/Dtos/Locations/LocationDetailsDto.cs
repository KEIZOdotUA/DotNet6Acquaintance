namespace Core.Dtos.Locations;

/// <summary>
/// Create/Update locations request DTO.
/// </summary>
public class LocationDetailsDto
{
    /// <summary>
    /// Gets or sets location name.
    /// </summary>
    /// <value>
    /// The name.
    /// </value>
    [Required]
    public string Name { get; init; }

    /// <summary>
    /// Gets or sets the lon.
    /// </summary>
    /// <value>
    /// Geographic longitude coordinates.
    /// </value>
    [Required]
    public float Lon { get; init; }

    /// <summary>
    /// Gets or sets the lat.
    /// </summary>
    /// <value>
    /// Geographic latitude coordinates.
    /// </value>
    [Required]
    public float Lat { get; init; }
}
