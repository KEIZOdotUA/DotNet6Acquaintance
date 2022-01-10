using Core.Dtos.Locations;

namespace Core.Modules.Locations.GetLocationDetails;

/// <summary>
/// Get location details request.
/// </summary>
/// <seealso cref="MediatR.IRequest&lt;Core.Dtos.Common.BaseResponseDto&lt;Core.Dtos.Locations.LocationFullDto&gt;&gt;" />
public class GetLocationDetailsRequest : IRequest<BaseResponseDto<LocationFullDto>>
{
    /// <summary>
    /// Gets or sets location identifier.
    /// </summary>
    /// <value>
    /// Location identifier.
    /// </value>
    public Guid Id { get; init; }
}
