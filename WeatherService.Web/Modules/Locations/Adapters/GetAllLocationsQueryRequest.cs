namespace WeatherService.Web.Modules.Locations.Adapters;

/// <summary>
/// Get all locations query request.
/// </summary>
/// <seealso cref="MediatR.IRequest&lt;WeatherService.Web.Modules.Locations.Core.LocationShortDto[]&gt;" />
public class GetAllLocationsQueryRequest : IRequest<LocationShortDto[]> { }
