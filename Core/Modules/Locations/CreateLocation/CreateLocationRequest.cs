using Core.Dtos.Locations;

namespace Core.Modules.Locations.CreateLocation;

/// <summary>
/// Create location request.
/// </summary>
/// <seealso cref="MediatR.IRequest&lt;Core.Dtos.Common.BaseResponseDto&lt;System.Guid&gt;&gt;" />
public class CreateLocationRequest : IRequest<BaseResponseDto<Guid>>
{
    /// <summary>
    /// Gets or sets locations details.
    /// </summary>
    /// <value>
    /// Locations details.
    /// </value>
    public LocationDetailsDto Details { get; init; }
}
