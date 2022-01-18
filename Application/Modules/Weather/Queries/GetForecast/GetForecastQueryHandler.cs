using Application.Dtos.Weather;
using Application.Models.Www7timer;
using Domain.Constants;
using Domain.Enums.Www7timer;
using Newtonsoft.Json;

namespace Application.Modules.Weather.Queries.GetForecast;

/// <summary>
/// Get forecast query handler.
/// </summary>
/// <seealso cref="MediatR.IRequestHandler&lt;Application.Modules.Weather.Queries.GetForecast.GetForecastQueryRequest, Application.Dtos.Common.BaseResponseDto&lt;Application.Interfaces.IHumanizedForecast[]&gt;&gt;" />
public class GetForecastQueryHandler : IRequestHandler<GetForecastQueryRequest, BaseResponseDto<IHumanizedForecast[]>>
{
    private readonly IGenericRepository<Location> _locationsRepository;
    private readonly IWww7timerService _www7TimerService;
    private readonly IMapper _mapper;

    private const string _brokenJsonPart = "\n\t\t\"temp2m\" : {\n\t\t\t\"max\" : ,\n\t\t\t\"min\" : \n\t\t},";

    /// <summary>
    /// Initializes a new instance of the <see cref="GetForecastQueryHandler" /> class.
    /// </summary>
    /// <param name="locationsRepository">The locations repository.</param>
    /// <param name="www7TimerService">The WWW7 timer service.</param>
    /// <param name="mapper">The mapper.</param>
    public GetForecastQueryHandler(
        IGenericRepository<Location> locationsRepository,
        IWww7timerService www7TimerService,
        IMapper mapper)
    {
        _locationsRepository = locationsRepository;
        _www7TimerService = www7TimerService;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles get forecast query request.
    /// </summary>
    /// <param name="queryRequest">The query request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>y
    /// Weather forecast.
    /// </returns>
    /// <exception cref="Application.Exceptions.NotFoundException">Location</exception>
    /// <exception cref="Application.Exceptions.ExternalServiceException"></exception>
    public async Task<BaseResponseDto<IHumanizedForecast[]>> Handle(
        GetForecastQueryRequest queryRequest,
        CancellationToken cancellationToken)
    {
        var location = await _locationsRepository.GetByIdAsync(queryRequest.LocationId);
        if (location == null)
            throw new NotFoundException(nameof(Location));

        var www7timersResponse = await _www7TimerService.GetForecastAsync(location.Lon, location.Lat, queryRequest.Type);
        if (!www7timersResponse.IsSuccessful)
            throw new ExternalServiceException(www7timersResponse.Content);

        var forecast = GetHumanizedForecast(www7timersResponse.Content, queryRequest.Type);

        return new BaseResponseDto<IHumanizedForecast[]> { Data = forecast };
    }

    /// <summary>
    /// Gets the humanized forecast.
    /// </summary>
    /// <param name="jsonContent">!7timer JSON response.</param>
    /// <param name="type">Forecast type.</param>
    /// <returns>
    /// Humanized forecast.
    /// </returns>
    private IHumanizedForecast[] GetHumanizedForecast(string jsonContent, Products type)
    {
        IForecast[] forecast;
        switch (type)
        {
            case Products.Civil:
                {
                    forecast = JsonConvert.DeserializeObject<Www7timerResponse<CivilForecast>>(jsonContent).DataSeries
                        .Where(x => !CheckBrokenValues(x))
                        .ToArray();

                    return _mapper.Map<HumanizedCivilForecastDto[]>(forecast);
                }
            case Products.Civillight:
                {
                    forecast = JsonConvert.DeserializeObject<Www7timerResponse<CivilLightForecast>>(jsonContent).DataSeries
                        .Where(x => !CheckBrokenValues(x))
                        .ToArray();

                    return _mapper.Map<HumanizedCivilLightForecastDto[]>(forecast);
                }
            default:
                {
                    jsonContent = jsonContent.Replace(_brokenJsonPart, String.Empty);
                    forecast = JsonConvert.DeserializeObject<Www7timerResponse<TwoWeakForecast>>(jsonContent).DataSeries
                        .Where(x => !CheckBrokenValues(x))
                        .ToArray();

                    return _mapper.Map<HumanizedTwoWeakForecastDto[]>(forecast);
                }
        }
    }

    /// <summary>
    /// Checks if entrie has 'broken' values.
    /// </summary>
    /// <param name="entrie">The entrie.</param>
    /// <returns>
    /// 'true' if some value is 'broken'
    /// </returns>
    private static bool CheckBrokenValues(IForecast entrie)
    {
        var propertyInfos = entrie.GetType().GetProperties();

        var hasBrokenStrings = propertyInfos
            .Where(pi => pi.PropertyType == typeof(string))
            .Select(pi => (string)pi.GetValue(entrie))
            .Any(x => x == Common.Www7timerBrokenStringValue);

        var hasBrokenInts = propertyInfos
            .Where(pi => pi.PropertyType == typeof(int))
            .Select(pi => (int)pi.GetValue(entrie))
            .Any(x => x == Common.Www7timerBrokenIntValue);

        var retValue = hasBrokenStrings || hasBrokenInts;

        return retValue;
    }
}
