using Application.Dtos.Locations;

namespace Application.Modules.Locations.Queries.GetLocationDetails;

/// <summary>
/// Get location details query handler.
/// </summary>
/// <seealso cref="MediatR.IRequestHandler&lt;Application.Modules.Locations.Queries.GetLocationDetails.GetLocationDetailsQueryRequest, Application.Dtos.Common.BaseResponseDto&lt;Application.Dtos.Locations.LocationFullDto&gt;&gt;" />
public class GetLocationDetailsQueryHandler : IRequestHandler<GetLocationDetailsQueryRequest, BaseResponseDto<LocationFullDto>>
{
    private readonly IGenericRepository<Location> _locationsRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetLocationDetailsQueryHandler"/> class.
    /// </summary>
    /// <param name="locationsRepository">The locations repository.</param>
    /// <param name="mapper">The mapper.</param>
    public GetLocationDetailsQueryHandler(IGenericRepository<Location> locationsRepository, IMapper mapper)
    {
        _locationsRepository = locationsRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles get location details query request.
    /// </summary>
    /// <param name="queryRequest">The query request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    /// Location details.
    /// </returns>
    /// <exception cref="NotFoundException">Location</exception>
    public async Task<BaseResponseDto<LocationFullDto>> Handle(
        GetLocationDetailsQueryRequest queryRequest,
        CancellationToken cancellationToken)
    {
        var location = await _locationsRepository.GetByIdAsync(queryRequest.Id);
        if (location == null)
            throw new NotFoundException(nameof(Location));

        var response = new BaseResponseDto<LocationFullDto>
        {
            Data = _mapper.Map<LocationFullDto>(location),
        };

        return response;
    }
}
