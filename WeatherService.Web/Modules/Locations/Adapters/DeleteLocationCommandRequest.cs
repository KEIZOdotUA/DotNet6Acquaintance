namespace WeatherService.Web.Modules.Locations.Adapters;

/// <summary>
/// Delete location command request.
/// </summary>
/// <seealso cref="IRequest&lt;Unit&gt;" />
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
