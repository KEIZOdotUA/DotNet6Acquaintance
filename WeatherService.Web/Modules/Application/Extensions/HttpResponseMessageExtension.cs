namespace WeatherService.Web.Modules.Application.Extensions;

/// <summary>
/// HttpResponseMessage extension.
/// </summary>
public static class HttpResponseMessageExtension
{
    /// <summary>
    /// Processes the response.
    /// </summary>
    /// <param name="httpResponseMessage">The HTTP response message.</param>
    /// <returns>
    /// HTTP response content.
    /// </returns>
    /// <exception cref="WeatherService.Web.Modules.Application.Exceptions.NotFoundException"></exception>
    /// <exception cref="WeatherService.Web.Modules.Application.Exceptions.ExistsException"></exception>
    public static async Task<string> ProcessResponse(this HttpResponseMessage httpResponseMessage)
    {
        var stringContent = await httpResponseMessage.Content.ReadAsStringAsync();

        if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
        {
            throw JsonConvert.DeserializeObject<string>(stringContent) switch
            {
                "NotFound" => new NotFoundException(),
                "Exists" => new ExistsException(),
                _ => new LocationsServiceException(stringContent),
            };
        }

        return stringContent;
    }
}
