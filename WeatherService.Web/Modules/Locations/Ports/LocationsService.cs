namespace WeatherService.Web.Modules.Locations.Ports;

/// <summary>
/// Location service interface implementation.
/// </summary>
/// <seealso cref="WeatherService.Web.Modules.Locations.Adapters.ILocationsService" />
public class LocationsService : ILocationsService
{
    private readonly IHttpClientFactory _httpClientFactory;

    private const string _jsonContentType = "application/json";

    /// <summary>
    /// Initializes a new instance of the <see cref="LocationsService"/> class.
    /// </summary>
    /// <param name="httpClientFactory">The HTTP client factory.</param>
    public LocationsService(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

    /// <summary>
    /// Creates location asynchronous.
    /// </summary>
    /// <param name="details">Location details.</param>
    /// <returns>
    /// Identifier of created location.
    /// </returns>
    public async Task<Guid> CreateAsync(LocationDetailsDto details)
    {
        var client = _httpClientFactory.CreateClient(Services.Locations.ToString());

        var request = new HttpRequestMessage(HttpMethod.Post, String.Empty)
        {
            Content = new StringContent(JsonConvert.SerializeObject(details), Encoding.UTF8, _jsonContentType)
        };

        var response = await client.SendAsync(request);
        var content = await response.ProcessResponse();

        var retValue = JsonConvert.DeserializeObject<Guid>(content);

        return retValue;
    }

    /// <summary>
    /// Deletes location asynchronous.
    /// </summary>
    /// <param name="id">Location identifier.</param>
    /// <returns></returns>
    /// <exception cref="System.NotImplementedException"></exception>
    public async Task DeleteAsync(Guid id)
    {
        var client = _httpClientFactory.CreateClient(Services.Locations.ToString());
        var request = new HttpRequestMessage(HttpMethod.Delete, id.ToString());
        var response = await client.SendAsync(request);
        
        await response.ProcessResponse();
    }

    /// <summary>
    /// Gets all locations asynchronous.
    /// </summary>
    /// <returns>
    /// Locations list.
    /// </returns>
    /// <exception cref="System.NotImplementedException"></exception>
    public async Task<IEnumerable<LocationShortDto>> GetAllAsync()
    {
        var client = _httpClientFactory.CreateClient(Services.Locations.ToString());
        var request = new HttpRequestMessage(HttpMethod.Get, String.Empty);
        var response = await client.SendAsync(request);
        var content = await response.ProcessResponse();

        var retValue = JsonConvert.DeserializeObject<LocationShortDto[]>(content);

        return retValue;
    }

    /// <summary>
    /// Gets location asynchronous.
    /// </summary>
    /// <param name="id">Location identifier.</param>
    /// <returns>
    /// Location details.
    /// </returns>
    /// <exception cref="System.NotImplementedException"></exception>
    public async Task<LocationFullDto> GetAsync(Guid id)
    {
        var client = _httpClientFactory.CreateClient(Services.Locations.ToString());
        var request = new HttpRequestMessage(HttpMethod.Get, id.ToString());
        var response = await client.SendAsync(request);

        var content = await response.ProcessResponse();

        var retValue = JsonConvert.DeserializeObject<LocationFullDto>(content);

        return retValue;
    }

    /// <summary>
    /// Updates location asynchronous.
    /// </summary>
    /// <param name="id">Location identifier.</param>
    /// <param name="details">Location details.</param>
    /// <exception cref="System.NotImplementedException"></exception>
    public async Task UpdateAsync(Guid id, LocationDetailsDto details)
    {
        var client = _httpClientFactory.CreateClient(Services.Locations.ToString());

        var request = new HttpRequestMessage(HttpMethod.Put, id.ToString())
        {
            Content = new StringContent(JsonConvert.SerializeObject(details), Encoding.UTF8, _jsonContentType)
        };

        var response = await client.SendAsync(request);

        await response.ProcessResponse();
    }

    /// <summary>
    /// Gets geographic coordinates asynchronous.
    /// </summary>
    /// <param name="id">Location identifier.</param>
    /// <returns>
    /// Geographic coordinates for location.
    /// </returns>
    public async Task<CoordinatesDto> GetCoordinatesAsync(Guid id)
    {
        var client = _httpClientFactory.CreateClient(Services.Locations.ToString());
        var request = new HttpRequestMessage(HttpMethod.Get, $"coordinates/{id}");
        var response = await client.SendAsync(request);

        var content = await response.ProcessResponse();

        var retValue = JsonConvert.DeserializeObject<CoordinatesDto>(content);

        return retValue;
    }
}
