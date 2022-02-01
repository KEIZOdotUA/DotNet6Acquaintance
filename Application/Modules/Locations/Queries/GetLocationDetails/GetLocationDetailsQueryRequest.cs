using Application.Dtos.Locations;

namespace Application.Modules.Locations.Queries.GetLocationDetails;

/// <summary>
/// Get location details query request.
/// </summary>
/// <seealso cref="MediatR.IRequest&lt;Application.Dtos.Common.BaseResponseDto&lt;Application.Dtos.Locations.LocationFullDto&gt;&gt;" />
public class GetLocationDetailsQueryRequest : IRequest<BaseResponseDto<LocationFullDto>>
{
    /// <summary>
    /// Gets or sets location identifier.
    /// </summary>
    /// <value>
    /// Location identifier.
    /// </value>
    public Guid Id { get; init; }
}
