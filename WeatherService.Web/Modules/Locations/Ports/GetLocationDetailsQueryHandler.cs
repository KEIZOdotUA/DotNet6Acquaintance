namespace WeatherService.Web.Modules.Locations.Ports;

/// <summary>
/// Get location details query handler.
/// </summary>
/// <seealso cref="MediatR.IRequestHandler&lt;WeatherService.Web.Modules.Locations.Adapters.GetLocationDetailsQueryRequest, WeatherService.Web.Modules.Locations.Core.LocationFullDto&gt;" />
public class GetLocationDetailsQueryHandler : IRequestHandler<GetLocationDetailsQueryRequest, LocationFullDto>
{
    private readonly ILocationsService _locationsService;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetLocationDetailsQueryHandler"/> class.
    /// </summary>
    /// <param name="locationsService">The locations service.</param>
    public GetLocationDetailsQueryHandler(ILocationsService locationsService) => _locationsService = locationsService;

    /// <summary>
    /// Handles get location details query request.
    /// </summary>
    /// <param name="queryRequest">The query request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    /// Location details.
    /// </returns>
    public async Task<LocationFullDto> Handle(
        GetLocationDetailsQueryRequest queryRequest,
        CancellationToken cancellationToken)
    {
        var queryResult = await _locationsService.GetAsync(queryRequest.Id);

        return queryResult;
    }
}
