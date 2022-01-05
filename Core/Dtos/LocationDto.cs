namespace Core.Dtos;

public record LocationDto
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
    public short Lon { get; set; }

    /// <summary>
    /// Gets or sets the lat.
    /// </summary>
    /// <value>
    /// Geographic latitude coordinates.
    /// </value>
    public short Lat { get; set; }
}
