namespace Core.Modules.Locations.UpdateLocation;

/// <summary>
/// Update location handler.
/// </summary>
/// <seealso cref="MediatR.IRequestHandler&lt;Core.Modules.Locations.UpdateLocation.UpdateLocationRequest, MediatR.Unit&gt;" />
public class UpdateLocationHandler : IRequestHandler<UpdateLocationRequest, Unit>
{
    private readonly IGenericRepository<Location> _locationsRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateLocationHandler"/> class.
    /// </summary>
    /// <param name="locationsRepository">The locations repository.</param>
    /// <param name="mapper">The mapper.</param>
    public UpdateLocationHandler(IGenericRepository<Location> locationsRepository, IMapper mapper)
    {
        _locationsRepository = locationsRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles update location handler request
    /// </summary>
    /// <param name="request"> Update location request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>
    /// Default and only value of the MediatR.Unit type.
    /// </returns>
    /// <exception cref="Core.Extensions.Exceptions.NotFoundException"></exception>
    /// <exception cref="Core.Extensions.Exceptions.ExistsException"></exception>
    public async Task<Unit> Handle(UpdateLocationRequest request, CancellationToken cancellationToken)
    {
        var location = await _locationsRepository.GetByIdAsync(request.Id);
        if (location == null)
            throw new NotFoundException();

        var existsLocations = await _locationsRepository
            .GetWhereAsync(x => x.Name == request.Details.Name || x.Lat == request.Details.Lat && x.Lon == request.Details.Lon);

        if (existsLocations.Any(x => x.Id != request.Id))
            throw new ExistsException();

        _mapper.Map(request.Details, location);

        await _locationsRepository.UpdateAsync(location);

        return Unit.Value;
    }
}
