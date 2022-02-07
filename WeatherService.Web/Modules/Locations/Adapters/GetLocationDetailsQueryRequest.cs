namespace WeatherService.Web.Modules.Locations.Adapters;

/// <summary>
/// Get location details query request.
/// </summary>
/// <seealso cref="MediatR.IRequest&lt;WeatherService.Web.Modules.Locations.Core.LocationFullDto&gt;" />
public class GetLocationDetailsQueryRequest : IRequest<LocationFullDto>
{
    /// <summary>
    /// Gets or sets location identifier.
    /// </summary>
    /// <value>
    /// Location identifier.
    /// </value>
    public Guid Id { get; init; }
}
