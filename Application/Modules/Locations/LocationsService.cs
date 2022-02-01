using Application.Dtos.Locations;

namespace Application.Modules.Locations;

/// <summary>
/// Locations service interface implementation.
/// </summary>
/// <seealso cref="Application.Interfaces.Services.ILocationsService" />
public class LocationsService : ILocationsService
{
    private readonly IGenericRepository<Location> _locationsRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="LocationsService"/> class.
    /// </summary>
    /// <param name="locationsRepository">The locations repository.</param>
    public LocationsService(IGenericRepository<Location> locationsRepository)
        => _locationsRepository = locationsRepository;

    /// <summary>
    /// Gets the same locations.
    /// </summary>
    /// <param name="location">Current location.</param>
    /// <returns>
    /// List of the same locations.
    /// </returns>
    public async Task<IEnumerable<Location>> GetSameLocations(LocationDetailsDto location)
    {
        var retValue = await _locationsRepository
            .GetWhereAsync(x => x.Name == location.Name || x.Lat == location.Lat && x.Lon == location.Lon);

        return retValue;
    }
}
