namespace Application.Modules.Locations.Commands.DeleteLocation;

/// <summary>
/// Delete location command request.
/// </summary>
/// <seealso cref="MediatR.IRequest&lt;MediatR.Unit&gt;" />
public class DeleteLocationCommandRequest : IRequest<Unit>
{
    /// <summary>
    /// Gets or sets location identifier.
    /// </summary>
    /// <value>
    /// Location identifier.
    /// </value>
    public Guid Id { get; init; }
}
