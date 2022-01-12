using Application.Dtos.Locations;

namespace Application.Interfaces.Services;

/// <summary>
/// Locations service interface.
/// </summary>
public interface ILocationsService
{
    /// <summary>
    /// Gets the same locations.
    /// </summary>
    /// <param name="location">Current location.</param>
    /// <returns>
    /// List of the same locations.
    /// </returns>
    public Task<IEnumerable<Location>> GetSameLocations(LocationDetailsDto location);
}
