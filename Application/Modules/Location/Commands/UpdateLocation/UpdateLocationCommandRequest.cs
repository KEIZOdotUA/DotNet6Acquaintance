using Application.Dtos.Locations;

namespace Application.Modules.Locations.Commands.UpdateLocation;

/// <summary>
/// Update location command request.
/// </summary>
/// <seealso cref="MediatR.IRequest&lt;MediatR.Unit&gt;" />
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
