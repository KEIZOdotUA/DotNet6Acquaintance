namespace WeatherService.Web.Modules.Locations.Ports;

/// <summary>
/// Delete location command handler
/// </summary>
/// <seealso cref="IRequestHandler&lt;Application.Modules.Locations.Commands.DeleteLocation.DeleteLocationCommandRequest, Unit&gt;" />
public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommandRequest, Unit>
{
    private readonly ILocationsService _locationsService;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteLocationCommandHandler"/> class.
    /// </summary>
    /// <param name="locationsService">The locations service.</param>
    public DeleteLocationCommandHandler(ILocationsService locationsService) => _locationsService = locationsService;

    /// <summary>
    /// Handles delete location command request.
    /// </summary>
    /// <param name="commandRequest">The command request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    /// Default and only value of the MediatR.Unit type.
    /// </returns>
    public async Task<Unit> Handle(DeleteLocationCommandRequest commandRequest, CancellationToken cancellationToken)
    {
        await _locationsService.DeleteAsync(commandRequest.Id);

        return Unit.Value;
    }
}
