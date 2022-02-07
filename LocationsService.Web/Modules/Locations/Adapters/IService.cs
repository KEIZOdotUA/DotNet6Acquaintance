namespace LocationsService.Web.Modules.Locations.Adapters;

public interface IService
{
    Task<Guid> CreateAsync(LocationDetailsDto details);

    Task<LocationFullDto> GetAsync(Guid id);

    Task<IEnumerable<LocationShortDto>> GetAllAsync();

    Task UpdateAsync(Guid id, LocationDetailsDto details);

    Task DeleteAsync(Guid id);

    Task<CoordinatesDto> GetCoordinatesAsync(Guid id);
}
