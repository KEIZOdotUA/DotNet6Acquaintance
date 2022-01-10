namespace Core.Dtos.Locations;

/// <summary>
/// Location short info DTO
/// </summary>
/// <seealso cref="System.IEquatable&lt;Core.Dtos.Locations.LocationShortDto&gt;" />
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
