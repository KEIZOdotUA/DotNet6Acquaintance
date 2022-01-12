using Application.Dtos.Locations;

namespace Application.Mappers;

/// <summary>
/// Application locations mapping profile.
/// </summary>
/// <seealso cref="AutoMapper.Profile" />
public class LocationsMappingProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LocationsMappingProfile"/> class.
    /// </summary>
    public LocationsMappingProfile()
    {
        CreateMap<LocationDetailsDto, Location>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ReverseMap();
        CreateMap<Location, LocationShortDto> ();
        CreateMap<Location, LocationFullDto>();
    }
}
