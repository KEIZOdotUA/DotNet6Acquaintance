namespace ForecastService.Web.Modules.Forecast.Ports;

public class Service : IService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IMapper _mapper;

    private const string _apiPath = "bin/api.pl";
    private const string _outputParameter = "output";
    private const string _unitParameter = "unit";
    private const string _brokenJsonPart = "\n\t\t\"temp2m\" : {\n\t\t\t\"max\" : ,\n\t\t\t\"min\" : \n\t\t},";
    private static readonly Dictionary<string, string> _defaultParameters = new()
    {
        { _outputParameter, "json" },
        { _unitParameter, "metric" },
    };

    public Service(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;

        var mapperConfiguration = new MapperConfiguration(c => c.AddProfile<ForecastMappingProfile>());
        _mapper = mapperConfiguration.CreateMapper();
    }

    public async Task<IEnumerable<IHumanizedForecast>> GetForecastAsync(float lon, float lat, Products type)
    {
        var www7timersResponse = await Get7timerForecast(lon, lat, type);
        var content = await www7timersResponse.Content.ReadAsStringAsync();
        if (!www7timersResponse.IsSuccessStatusCode)
            throw new Exception(content);

        var retValue = GetHumanizedForecast(content, type);
        return retValue;
    }

    private async Task<HttpResponseMessage> Get7timerForecast(float lon, float lat, Products product)
    {
        var client = _httpClientFactory.CreateClient(Services.www7timer.ToString());
        var queryString = new Dictionary<string, string>()
        {
            { nameof(lon), lon.ToString() },
            { nameof(lat), lat.ToString() },
            { nameof(product), product.ToString().ToLower() },
            { _outputParameter, _defaultParameters[_outputParameter] },
            { _unitParameter, _defaultParameters[_unitParameter] },
        };
        var requestUri = QueryHelpers.AddQueryString(_apiPath, queryString);
        var request = new HttpRequestMessage(HttpMethod.Get, requestUri);

        var response = await client.SendAsync(request);

        return response;
    }

    private IEnumerable<IHumanizedForecast> GetHumanizedForecast(string jsonContent, Products type)
    {
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        IForecast[] forecast;
        switch (type)
        {
            case Products.Civil:
                {
                    forecast = JsonSerializer.Deserialize<Www7timerResponse<CivilForecast>>(jsonContent, options).DataSeries
                        .Where(x => !CheckBrokenValues(x))
                        .ToArray();

                    return _mapper.Map<HumanizedCivilForecastDto[]>(forecast);
                }
            case Products.Civillight:
                {
                    forecast = JsonSerializer.Deserialize<Www7timerResponse<CivilLightForecast>>(jsonContent, options).DataSeries
                        .Where(x => !CheckBrokenValues(x))
                        .ToArray();

                    return _mapper.Map<HumanizedCivilLightForecastDto[]>(forecast);
                }
            default:
                {
                    jsonContent = jsonContent.Replace(_brokenJsonPart, string.Empty);
                    forecast = JsonSerializer.Deserialize<Www7timerResponse<TwoWeakForecast>>(jsonContent, options).DataSeries
                        .Where(x => !CheckBrokenValues(x))
                        .ToArray();

                    return _mapper.Map<HumanizedTwoWeakForecastDto[]>(forecast);
                }
        }
    }

    private static bool CheckBrokenValues(IForecast entrie)
    {
        var propertyInfos = entrie.GetType().GetProperties();

        var hasBrokenStrings = propertyInfos
            .Where(pi => pi.PropertyType == typeof(string))
            .Select(pi => (string)pi.GetValue(entrie))
            .Any(x => x == CommonConstants.Www7timerBrokenStringValue);

        var hasBrokenInts = propertyInfos
            .Where(pi => pi.PropertyType == typeof(int))
            .Select(pi => (int)pi.GetValue(entrie))
            .Any(x => x == CommonConstants.Www7timerBrokenIntValue);

        var retValue = hasBrokenStrings || hasBrokenInts;

        return retValue;
    }
}
