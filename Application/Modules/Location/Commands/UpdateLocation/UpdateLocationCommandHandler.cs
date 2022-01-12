namespace Application.Modules.Locations.Commands.UpdateLocation;

/// <summary>
/// Update location command handler.
/// </summary>
/// <seealso cref="MediatR.IRequestHandler&lt;Application.Modules.Locations.Commands.UpdateLocation.UpdateLocationCommandRequest, MediatR.Unit&gt;" />
public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommandRequest, Unit>
{
    private readonly IGenericRepository<Location> _locationsRepository;
    private readonly ILocationsService _locationsService;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateLocationCommandHandler"/> class.
    /// </summary>
    /// <param name="locationsRepository">The locations repository.</param>
    /// <param name="mapper">The mapper.</param>
    public UpdateLocationCommandHandler(
        IGenericRepository<Location> locationsRepository,
        ILocationsService locationsService, 
        IMapper mapper)
    {
        _locationsRepository = locationsRepository;
        _locationsService = locationsService;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles update location command request.
    /// </summary>
    /// <param name="commandRequest">The command request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    /// Default and only value of the MediatR.Unit type.
    /// </returns>
    /// <exception cref="NotFoundException">Location</exception>
    /// <exception cref="ExistsException">Location</exception>
    public async Task<Unit> Handle(UpdateLocationCommandRequest commandRequest, CancellationToken cancellationToken)
    {
        var location = await _locationsRepository.GetByIdAsync(commandRequest.Id);
        if (location == null)
            throw new NotFoundException(nameof(Location));

        var sameLocations = await _locationsService.GetSameLocations(commandRequest.Details);
        if (sameLocations.Any(x => x.Id != commandRequest.Id))
            throw new ExistsException(nameof(Location));

        _mapper.Map(commandRequest.Details, location);

        await _locationsRepository.UpdateAsync(location);

        return Unit.Value;
    }
}
