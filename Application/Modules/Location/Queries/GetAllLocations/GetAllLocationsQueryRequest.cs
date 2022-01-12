using Application.Dtos.Locations;

namespace Application.Modules.Locations.Queries.GetAllLocations;

/// <summary>
/// Get all locations query request.
/// </summary>
/// <seealso cref="MediatR.IRequest&lt;Application.Dtos.Common.BaseResponseDto&lt;Application.Dtos.Locations.LocationShortDto[]&gt;&gt;" />
public class GetAllLocationsQueryRequest : IRequest<BaseResponseDto<LocationShortDto[]>> { }
