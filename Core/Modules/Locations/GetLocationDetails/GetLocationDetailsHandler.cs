using Core.Dtos.Locations;

namespace Core.Modules.Locations.GetLocationDetails;

/// <summary>
/// Get location details handler.
/// </summary>
/// <seealso cref="MediatR.IRequestHandler&lt;Core.Modules.Locations.GetLocationDetails.GetLocationDetailsRequest, Core.Dtos.Common.BaseResponseDto&lt;Core.Dtos.Locations.LocationFullDto&gt;&gt;" />
public class GetLocationDetailsHandler : IRequestHandler<GetLocationDetailsRequest, BaseResponseDto<LocationFullDto>>
{
    private readonly IGenericRepository<Location> _locationsRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetLocationDetailsHandler"/> class.
    /// </summary>
    /// <param name="locationsRepository">The locations repository.</param>
    /// <param name="mapper">The mapper.</param>
    public GetLocationDetailsHandler(IGenericRepository<Location> locationsRepository, IMapper mapper)
    {
        _locationsRepository = locationsRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles get location details request
    /// </summary>
    /// <param name="request">The request parameters</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>
    /// Location details.
    /// </returns>
    /// <exception cref="Core.Extensions.Exceptions.NotFoundException"></exception>
    public async Task<BaseResponseDto<LocationFullDto>> Handle(
        GetLocationDetailsRequest request,
        CancellationToken cancellationToken)
    {
        var location = await _locationsRepository.GetByIdAsync(request.Id);
        if (location == null)
            throw new NotFoundException();

        var response = new BaseResponseDto<LocationFullDto>
        {
            Data = _mapper.Map<LocationFullDto>(location),
        };

        return response;
    }
}
