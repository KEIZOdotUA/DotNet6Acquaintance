namespace Domain.Entities;

/// <summary>
/// Location entity.
/// </summary>
/// <seealso cref="Domain.Entities.EntityBase" />
public class Location : EntityBase
{
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
