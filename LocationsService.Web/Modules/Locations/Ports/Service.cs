namespace LocationsService.Web.Modules.Locations.Ports;

public class Service : IService
{
    private readonly IRepository _repository;

    public Service(IRepository repository) => _repository = repository;

    public async Task<Guid> CreateAsync(LocationDetailsDto details)
    {
        var sameLocations = await _repository.GetSameAsync(details.Name, details.Lon, details.Lat);
        if (sameLocations.Any())
            throw new Exception(Errors.Exists.ToString());

        var newLocation = new Location
        {
            Id = Guid.NewGuid(),
            Name = details.Name,
            Lon = details.Lon,
            Lat = details.Lat,
        };

        await _repository.CreateAsync(newLocation);

        return newLocation.Id;
    }

    public async Task<LocationFullDto> GetAsync(Guid id)
    {
        var location = await _repository.GetByIdAsync(id);
        if (location == null)
            throw new Exception(Errors.NotFound.ToString());

        var retValue = new LocationFullDto
        {
            Id = id,
            Name = location.Name,
            Lon = location.Lon,
            Lat = location.Lat,
        };

        return retValue;
    }

    public async Task<IEnumerable<LocationShortDto>> GetAllAsync()
    {
        var allLocations = await _repository.GetAllAsync();

        var retValue = allLocations.Select(
            x => new LocationShortDto
            {
                Id = x.Id,
                Name = x.Name,
            });

        return retValue;
    }

    public async Task UpdateAsync(Guid id, LocationDetailsDto details)
    {
        var location = await _repository.GetByIdAsync(id);
        if (location == null)
            throw new Exception(Errors.NotFound.ToString());

        var sameLocations = await _repository.GetSameAsync(details.Name, details.Lon, details.Lat);
        if (sameLocations.Any(x => x.Id != id))
            throw new Exception(Errors.Exists.ToString());

        location.Name = details.Name;
        location.Lon = details.Lon;
        location.Lat = details.Lat;

        await _repository.UpdateAsync(location);
    }

    public async Task DeleteAsync(Guid id)
    {
        var location = await _repository.GetByIdAsync(id);
        if (location == null)
            throw new Exception(Errors.NotFound.ToString());

        await _repository.DeleteAsync(location);
    }

    public async Task<CoordinatesDto> GetCoordinatesAsync(Guid id)
    {
        var location = await _repository.GetByIdAsync(id);
        if (location == null)
            throw new Exception(Errors.NotFound.ToString());

        var retValue = new CoordinatesDto
        {
            Lon = location.Lon,
            Lat = location.Lat,
        };

        return retValue;
    }
}
