namespace WeatherService.Web.Modules.Forecast.Ports;

/// <summary>
/// Get forecast query handler.
/// </summary>
/// <seealso cref="MediatR.IRequestHandler&lt;WeatherService.Web.Modules.Forecast.Adapters.GetForecastQueryRequest, WeatherService.Web.Modules.Forecast.Core.IHumanizedForecast[]&gt;" />
public class GetForecastQueryHandler : IRequestHandler<GetForecastQueryRequest, IHumanizedForecast[]>
{
    private readonly ILocationsService _locationsService;
    private readonly IForecastService _forecastService;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetForecastQueryHandler"/> class.
    /// </summary>
    /// <param name="locationsService">The locations service.</param>
    /// <param name="forecastService">The forecast service.</param>
    public GetForecastQueryHandler(ILocationsService locationsService, IForecastService forecastService)
    {
        _locationsService = locationsService;
        _forecastService = forecastService;
    }

    /// <summary>
    /// Handles get forecast query request.
    /// </summary>
    /// <param name="queryRequest">The query request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>y
    /// Weather forecast.
    /// </returns>
    public async Task<IHumanizedForecast[]> Handle(GetForecastQueryRequest queryRequest, CancellationToken cancellationToken)
    {
        var locationCoordinates = await _locationsService.GetCoordinatesAsync(queryRequest.LocationId);

        var forecast = await _forecastService.GetForecastAsync(
            locationCoordinates.Lon,
            locationCoordinates.Lat,
            queryRequest.Type);

        var queryResult = forecast.ToArray();

        return queryResult;
    }
}
