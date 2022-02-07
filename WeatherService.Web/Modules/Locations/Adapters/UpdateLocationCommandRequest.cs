namespace WeatherService.Web.Modules.Locations.Adapters;

/// <summary>
/// Update location command request.
/// </summary>
/// <seealso cref="IRequest&lt;Unit&gt;" />
public class UpdateLocationCommandRequest : IRequest<Unit>
{
    /// <summary>
    /// Gets or sets location identifier.
    /// </summary>
    /// <value>
    /// Location identifier.
    /// </value>
    public Guid Id { get; init; }

    /// <summary>
    /// Gets or sets locations details.
    /// </summary>
    /// <value>
    /// Locations details.
    /// </value>
    public LocationDetailsDto Details { get; init; }
}
