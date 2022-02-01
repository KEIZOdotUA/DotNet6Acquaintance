namespace Application.Modules.Locations.Commands.CreateLocation;

/// <summary>
/// Create location command handler.
/// </summary>
/// <seealso cref="MediatR.IRequestHandler&lt;Application.Modules.Locations.Commands.CreateLocation.CreateLocationCommandRequest, Application.Dtos.Common.BaseResponseDto&lt;System.Guid&gt;&gt;" />
public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommandRequest, BaseResponseDto<Guid>>
{
    private readonly IGenericRepository<Location> _locationsRepository;
    private readonly ILocationsService _locationsService;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateLocationCommandHandler" /> class.
    /// </summary>
    /// <param name="locationsRepository">The locations repository.</param>
    /// <param name="locationsService">The locations service.</param>
    /// <param name="mapper">The mapper.</param>
    public CreateLocationCommandHandler(
        IGenericRepository<Location> locationsRepository,
        ILocationsService locationsService,
        IMapper mapper)
    {
        _locationsRepository = locationsRepository;
        _locationsService = locationsService;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles create location command.
    /// </summary>
    /// <param name="commandRequest">The command request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    /// Identifier of created location.
    /// </returns>
    /// <exception cref="ExistsException">Location</exception>
    public async Task<BaseResponseDto<Guid>> Handle(
        CreateLocationCommandRequest commandRequest,
        CancellationToken cancellationToken)
    {
        var sameLocations = await _locationsService.GetSameLocations(commandRequest.Details);
        if (sameLocations.Any())
            throw new ExistsException(nameof(Location));

        var newLocation = _mapper.Map<Location>(commandRequest.Details);
        newLocation.Id = Guid.NewGuid();

        await _locationsRepository.CreateAsync(newLocation);

        var commandResponse = new BaseResponseDto<Guid>() { Data = newLocation.Id };

        return commandResponse;
    }
}
