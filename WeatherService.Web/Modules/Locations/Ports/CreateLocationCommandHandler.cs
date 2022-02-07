namespace WeatherService.Web.Modules.Locations.Ports;

/// <summary>
/// Create location command handler.
/// </summary>
/// <seealso cref="MediatR.IRequestHandler&lt;WeatherService.Web.Modules.Locations.Adapters.CreateLocationCommandRequest, System.Guid&gt;" />
public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommandRequest, Guid>
{
    private readonly ILocationsService _locationsService;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateLocationCommandHandler" /> class.
    /// </summary>
    /// <param name="locationsService">The locations service.</param>
    public CreateLocationCommandHandler(ILocationsService locationsService) => _locationsService = locationsService;

    /// <summary>
    /// Handles create location command.
    /// </summary>
    /// <param name="commandRequest">The command request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    /// Identifier of created location.
    /// </returns>
    public async Task<Guid> Handle(
        CreateLocationCommandRequest commandRequest,
        CancellationToken cancellationToken)
    {
        var commandResponse = await _locationsService.CreateAsync(commandRequest.Details);

        return commandResponse;
    }
}
