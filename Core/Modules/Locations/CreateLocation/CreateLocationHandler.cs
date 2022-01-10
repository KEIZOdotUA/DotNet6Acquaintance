namespace Core.Modules.Locations.CreateLocation;

/// <summary>
/// Create location handler.
/// </summary>
/// <seealso cref="MediatR.IRequestHandler&lt;Core.Modules.Locations.CreateLocation.CreateLocationRequest, Core.Dtos.Common.BaseResponseDto&lt;System.Guid&gt;&gt;" />
public class CreateLocationHandler : IRequestHandler<CreateLocationRequest, BaseResponseDto<Guid>>
{
    private readonly IGenericRepository<Location> _locationsRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateLocationHandler"/> class.
    /// </summary>
    /// <param name="locationsRepository">The locations repository.</param>
    /// <param name="mapper">The mapper.</param>
    public CreateLocationHandler(IGenericRepository<Location> locationsRepository, IMapper mapper)
    {
        _locationsRepository = locationsRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles create location request
    /// </summary>
    /// <param name="request">Location info</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>
    /// Identifier of created location.
    /// </returns>
    /// <exception cref="Core.Extensions.Exceptions.ExistsException"></exception>
    public async Task<BaseResponseDto<Guid>> Handle(CreateLocationRequest request, CancellationToken cancellationToken)
    {
        var existsLocations = await _locationsRepository
            .GetWhereAsync(x => x.Name == request.Details.Name || x.Lat == request.Details.Lat && x.Lon == request.Details.Lon);

        if (existsLocations.Any())
            throw new ExistsException();

        var newLocation = _mapper.Map<Location>(request.Details);
        newLocation.Id = Guid.NewGuid();

        await _locationsRepository.CreateAsync(newLocation);

        var response = new BaseResponseDto<Guid>() { Data = newLocation.Id };

        return response;
    }
}
