namespace LocationsService.Web.Modules.Locations.Adapters;

public interface IRepository
{
    Task<Location> GetByIdAsync(Guid id);

    Task CreateAsync(Location location);

    Task UpdateAsync(Location location);

    Task DeleteAsync(Location location);

    Task<IEnumerable<Location>> GetAllAsync();

    Task<IEnumerable<Location>> GetSameAsync(string name, float lon, float lat);
}
