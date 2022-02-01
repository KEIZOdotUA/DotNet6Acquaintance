using Application.Dtos.Locations;

namespace Application.Modules.Locations.Commands.CreateLocation;

/// <summary>
/// Create location command request.
/// </summary>
/// <seealso cref="MediatR.IRequest&lt;Application.Dtos.Common.BaseResponseDto&lt;System.Guid&gt;&gt;" />
public class CreateLocationCommandRequest : IRequest<BaseResponseDto<Guid>>
{
    /// <summary>
    /// Gets or sets locations details.
    /// </summary>
    /// <value>
    /// Locations details.
    /// </value>
    public LocationDetailsDto Details { get; init; }
}
