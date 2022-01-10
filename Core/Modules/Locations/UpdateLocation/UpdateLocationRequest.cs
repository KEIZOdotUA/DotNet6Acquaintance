using Core.Dtos.Locations;

namespace Core.Modules.Locations.UpdateLocation;

/// <summary>
/// Update location request.
/// </summary>
/// <seealso cref="MediatR.IRequest&lt;MediatR.Unit&gt;" />
public class UpdateLocationRequest : IRequest<Unit>
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
