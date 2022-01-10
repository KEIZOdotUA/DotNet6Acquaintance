using Core.Dtos.Locations;

namespace Core.Extensions;

/// <summary>
/// Application general mapping profile.
/// </summary>
/// <seealso cref="AutoMapper.Profile" />
public class MappingProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MappingProfile"/> class.
    /// </summary>
    public MappingProfile()
    {
        CreateMap<LocationDetailsDto, Location>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ReverseMap();
        CreateMap<Location, LocationShortDto> ();
        CreateMap<Location, LocationFullDto>();
    }
}
