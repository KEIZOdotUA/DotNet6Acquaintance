using Core.Dtos.Locations;

namespace Core.Modules.Locations.GetAllLocations;

/// <summary>
/// Get all locations request.
/// </summary>
/// <seealso cref="MediatR.IRequest&lt;Core.Dtos.Common.BaseResponseDto&lt;Core.Dtos.Locations.LocationShortDto[]&gt;&gt;" />
public class GetAllLocationsRequest : IRequest<BaseResponseDto<LocationShortDto[]>>
{
}
