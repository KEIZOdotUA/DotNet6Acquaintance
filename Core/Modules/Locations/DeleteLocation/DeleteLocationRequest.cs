namespace Core.Modules.Locations.DeleteLocation;

/// <summary>
/// Delete location request.
/// </summary>
/// <seealso cref="MediatR.IRequest&lt;MediatR.Unit&gt;" />
public class DeleteLocationRequest : IRequest<Unit>
{
    /// <summary>
    /// Gets or sets location identifier.
    /// </summary>
    /// <value>
    /// Location identifier.
    /// </value>
    public Guid Id { get; init; }
}
