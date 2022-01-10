using Core.Dtos.Locations;

namespace Core.Modules.Locations.GetAllLocations;

/// <summary>
/// Get all locations handler.
/// </summary>
/// <seealso cref="MediatR.IRequestHandler&lt;Core.Modules.Locations.GetAllLocations.GetAllLocationsRequest, Core.Dtos.Common.BaseResponseDto&lt;Core.Dtos.Locations.LocationShortDto[]&gt;&gt;" />
public class GetAllLocationsHandler : IRequestHandler<GetAllLocationsRequest, BaseResponseDto<LocationShortDto[]>>
{
    private readonly IGenericRepository<Location> _locationsRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetAllLocationsHandler"/> class.
    /// </summary>
    /// <param name="locationsRepository">The locations repository.</param>
    /// <param name="mapper">The mapper.</param>
    public GetAllLocationsHandler(IGenericRepository<Location> locationsRepository, IMapper mapper)
    {
        _locationsRepository = locationsRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles get all locations request
    /// </summary>
    /// <param name="request">The request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>
    /// List of all locations.
    /// </returns>
    public async Task<BaseResponseDto<LocationShortDto[]>> Handle(
        GetAllLocationsRequest request,
        CancellationToken cancellationToken)
    {
        var allLocations = await _locationsRepository.GetAllAsync();

        var response = new BaseResponseDto<LocationShortDto[]>
        {
            Data = _mapper.Map<LocationShortDto[]>(allLocations),
        };

        return response;
    }
}
