namespace WeatherService.Web.Modules.Locations.Adapters;

/// <summary>
/// Create location command request.
/// </summary>
/// <seealso cref="MediatR.IRequest&lt;System.Guid&gt;" />
public class CreateLocationCommandRequest : IRequest<Guid>
{
    /// <summary>
    /// Gets or sets locations details.
    /// </summary>
    /// <value>
    /// Locations details.
    /// </value>
    public LocationDetailsDto Details { get; init; }
}
