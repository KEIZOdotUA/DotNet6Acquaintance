using Application.Dtos.Locations;

namespace Application.Modules.Locations.Queries.GetAllLocations;

/// <summary>
/// Get all locations query handler.
/// </summary>
/// <seealso cref="MediatR.IRequestHandler&lt;Application.Modules.Locations.Queries.GetAllLocations.GetAllLocationsQueryRequest, Application.Dtos.Common.BaseResponseDto&lt;Application.Dtos.Locations.LocationShortDto[]&gt;&gt;" />
public class GetAllLocationsQueryHandler : IRequestHandler<GetAllLocationsQueryRequest, BaseResponseDto<LocationShortDto[]>>
{
    private readonly IGenericRepository<Location> _locationsRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetAllLocationsQueryHandler"/> class.
    /// </summary>
    /// <param name="locationsRepository">The locations repository.</param>
    /// <param name="mapper">The mapper.</param>
    public GetAllLocationsQueryHandler(IGenericRepository<Location> locationsRepository, IMapper mapper)
    {
        _locationsRepository = locationsRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles get all locations query request.
    /// </summary>
    /// <param name="queryRequest">The query request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    /// List of all locations.
    /// </returns>
    public async Task<BaseResponseDto<LocationShortDto[]>> Handle(
        GetAllLocationsQueryRequest queryRequest,
        CancellationToken cancellationToken)
    {
        var allLocations = await _locationsRepository.GetAllAsync();

        var queryResponse = new BaseResponseDto<LocationShortDto[]>
        {
            Data = _mapper.Map<LocationShortDto[]>(allLocations),
        };

        return queryResponse;
    }
}
