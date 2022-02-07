namespace WeatherService.Web.Modules.Locations.Ports;

/// <summary>
/// Get all locations query handler.
/// </summary>
/// <seealso cref="MediatR.IRequestHandler&lt;WeatherService.Web.Modules.Locations.Adapters.GetAllLocationsQueryRequest, WeatherService.Web.Modules.Locations.Core.LocationShortDto[]&gt;" />
public class GetAllLocationsQueryHandler : IRequestHandler<GetAllLocationsQueryRequest, LocationShortDto[]>
{
    private readonly ILocationsService _locationsService;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetAllLocationsQueryHandler"/> class.
    /// </summary>
    /// <param name="locationsService">The locations service.</param>
    public GetAllLocationsQueryHandler(ILocationsService locationsService) => _locationsService = locationsService;

    /// <summary>
    /// Handles get all locations query request.
    /// </summary>
    /// <param name="queryRequest">The query request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    /// List of all locations.
    /// </returns>
    public async Task<LocationShortDto[]> Handle(
        GetAllLocationsQueryRequest queryRequest,
        CancellationToken cancellationToken)
    {
        var queryResponse = (await _locationsService.GetAllAsync()).ToArray();

        return queryResponse;
    }
}
