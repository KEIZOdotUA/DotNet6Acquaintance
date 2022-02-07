namespace WeatherService.Web.Modules.Locations.Adapters;

/// <summary>
/// Locations service interface.
/// </summary>
public interface ILocationsService
{
    /// <summary>
    /// Creates location asynchronous.
    /// </summary>
    /// <param name="details">Location details.</param>
    /// <returns>
    /// Identifier of created location.
    /// </returns>
    Task<Guid> CreateAsync(LocationDetailsDto details);

    /// <summary>
    /// Gets location asynchronous.
    /// </summary>
    /// <param name="id">Location identifier.</param>
    /// <returns>
    /// Location details.
    /// </returns>
    Task<LocationFullDto> GetAsync(Guid id);

    /// <summary>
    /// Gets all locations asynchronous.
    /// </summary>
    /// <returns>
    /// Locations list.
    /// </returns>
    Task<IEnumerable<LocationShortDto>> GetAllAsync();

    /// <summary>
    /// Updates location asynchronous.
    /// </summary>
    /// <param name="id">Location identifier.</param>
    /// <param name="details">Location details.</param>
    Task UpdateAsync(Guid id, LocationDetailsDto details);

    /// <summary>
    /// Deletes location asynchronous.
    /// </summary>
    /// <param name="id">Location identifier.</param>
    Task DeleteAsync(Guid id);

    /// <summary>
    /// Gets geographic coordinates asynchronous.
    /// </summary>
    /// <param name="id">Location identifier.</param>
    /// <returns>
    /// Geographic coordinates for location.
    /// </returns>
    Task<CoordinatesDto> GetCoordinatesAsync(Guid id);
}
