namespace WeatherService.Web.Modules.Locations.Ports;

/// <summary>
/// Update location command handler.
/// </summary>
/// <seealso cref="IRequestHandler&lt;Application.Modules.Locations.Commands.UpdateLocation.UpdateLocationCommandRequest, Unit&gt;" />
public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommandRequest, Unit>
{
    private readonly ILocationsService _locationsService;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateLocationCommandHandler"/> class.
    /// </summary>
    /// <param name="locationsService">The locations service.</param>
    public UpdateLocationCommandHandler(ILocationsService locationsService) => _locationsService = locationsService;

    /// <summary>
    /// Handles update location command request.
    /// </summary>
    /// <param name="commandRequest">The command request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    /// Default and only value of the MediatR.Unit type.
    /// </returns>
    public async Task<Unit> Handle(UpdateLocationCommandRequest commandRequest, CancellationToken cancellationToken)
    {
        await _locationsService.UpdateAsync(commandRequest.Id, commandRequest.Details);

        return Unit.Value;
    }
}
