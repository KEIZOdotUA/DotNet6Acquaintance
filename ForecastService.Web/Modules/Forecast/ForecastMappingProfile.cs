namespace ForecastService.Web.Modules.Forecast;

public class ForecastMappingProfile : Profile
{
    #region Weather descriptions

    private readonly Dictionary<int, string> _cloudCoverDescription = new()
    {
        { 1, "0%-6%" },
        { 2, "6%-19%" },
        { 3, "19%-31%" },
        { 4, "31%-44%" },
        { 5, "44%-56%" },
        { 6, "56%-69%" },
        { 7, "69%-81%" },
        { 8, "81%-94%" },
        { 9, "94%-100%" },
        { CommonConstants.Www7timerBrokenIntValue, CommonConstants.Www7timerBrokenStringValue },
    };

    private readonly Dictionary<string, string> _precipitationTypeDescription = new()
    {
        { "snow", "snow" },
        { "rain", "rain" },
        { "frzr", "freezing rain" },
        { "icep", "ice pellets" },
        { "none", string.Empty },
        { CommonConstants.Www7timerBrokenStringValue, CommonConstants.Www7timerBrokenStringValue },
    };

    private readonly Dictionary<int, string> _precipitationAmountDescription = new()
    {
        { 0, string.Empty },
        { 1, "0-0.25mm/hr" },
        { 2, "0.25-1mm/hr" },
        { 3, "1-4mm/hr" },
        { 4, "4-10mm/hr" },
        { 5, "10-16mm/hr" },
        { 6, "16-30mm/hr" },
        { 7, "30-50mm/hr%" },
        { 8, "50-75mm/hr" },
        { 9, "over 75mm/hr" },
        { CommonConstants.Www7timerBrokenIntValue, CommonConstants.Www7timerBrokenStringValue },
    };
    private const string _civilClearDescription = "total cloud cover less than 20%";
    private const string _pcloudyDescription = "total cloud cover between 20%-60%";
    private const string _civilMcloudyDescription = "Total cloud cover between 60%-80%";
    private const string _civilCloudyDescription = "total cloud cover over over 80%";
    private const string _humidDescription = "	relative humidity over 90% with total cloud cover less than 60%";
    private const string _lightrainDescription = "precipitation rate less than 4mm/hr with total cloud cover more than 80%";
    private const string _oshowerDescription = "precipitation rate less than 4mm/hr with total cloud cover between 60%-80%";
    private const string _ishowerDescription = "precipitation rate less than 4mm/hr with total cloud cover less than 60%";
    private const string _lightsnowDescription = "precipitation rate less than 4mm/hr";
    private const string _civilRainDescription = "precipitation rate over 4mm/hr";
    private const string _civilSnowDescription = "precipitation rate over 4mm/hr";
    private const string _rainsnowDescription = "precipitation type to be ice pellets or freezing rain";
    private const string _civilTsDescription = "lifted Index less than -5 with precipitation rate below 4mm/hr";
    private const string _civilTsRainDescription = "Lifted Index less than -5 with precipitation rate over 4mm/hr";

    private readonly Dictionary<string, string> _civilWeatherDescription = new()
    {
        { "clear", _civilClearDescription },
        { "clearday", _civilClearDescription },
        { "clearnight", _civilClearDescription },
        { "pcloudy", _pcloudyDescription },
        { "pcloudyday", _pcloudyDescription },
        { "pcloudynight", _pcloudyDescription },
        { "mcloudy", _civilMcloudyDescription },
        { "mcloudyday", _civilMcloudyDescription },
        { "mcloudynight", _civilMcloudyDescription },
        { "cloudy", _civilCloudyDescription },
        { "cloudyday", _civilCloudyDescription },
        { "cloudynight", _civilCloudyDescription },
        { "humid", _humidDescription },
        { "humidday", _humidDescription },
        { "humidnight", _humidDescription },
        { "lightrain", _lightrainDescription },
        { "lightrainday", _lightrainDescription },
        { "lightrainnight", _lightrainDescription },
        { "oshower", _oshowerDescription },
        { "oshowerday", _oshowerDescription },
        { "oshowernight", _oshowerDescription },
        { "ishower", _ishowerDescription },
        { "ishowerday", _ishowerDescription },
        { "ishowernight", _ishowerDescription },
        { "lightsnow", _lightsnowDescription },
        { "lightsnowday", _lightsnowDescription },
        { "lightsnownight", _lightsnowDescription },
        { "rain", _civilRainDescription },
        { "rainday", _civilRainDescription },
        { "rainnight", _civilRainDescription },
        { "snow", _civilSnowDescription },
        { "snowday", _civilSnowDescription },
        { "snownight", _civilSnowDescription },
        { "rainsnow", _rainsnowDescription },
        { "rainsnowday", _rainsnowDescription },
        { "rainsnownight", _rainsnowDescription },
        { "ts", _civilTsDescription },
        { "tsday", _civilTsDescription },
        { "tsnight", _civilTsDescription },
        { "tsrain", _civilTsRainDescription },
        { "tsrainday", _civilTsRainDescription },
        { "tsrainnight", _civilTsRainDescription },
        { CommonConstants.Www7timerBrokenStringValue, CommonConstants.Www7timerBrokenStringValue },
    };

    private readonly Dictionary<int, string> _windDescription = new()
    {
        { 1, "Below 0.3m/s (calm)" },
        { 2, "0.3-3.4m/s (light)" },
        { 3, "3.4-8.0m/s (moderate)" },
        { 4, "8.0-10.8m/s (fresh)" },
        { 5, "10.8-17.2m/s (strong)" },
        { 6, "17.2-24.5m/s (gale)" },
        { 7, "24.5-32.6m/s (storm)" },
        { 8, "over 32.6m/s (hurricane)" },
        { CommonConstants.Www7timerBrokenIntValue, CommonConstants.Www7timerBrokenStringValue },
    };

    private readonly Dictionary<int, string> _relativeHumidityDescription = new()
    {
        { -4, "0%-5%" },
        { -3, "5%-10%" },
        { -2, "10%-15%" },
        { -1, "15%-20%" },
        { 0, "20%-25%" },
        { 1, "25%-30%" },
        { 2, "30%-35%" },
        { 3, "35%-40%" },
        { 4, "40%-45%" },
        { 5, "45%-50%" },
        { 6, "50%-55%" },
        { 7, "55%-60%" },
        { 8, "60%-65%" },
        { 9, "65%-70%" },
        { 10, "70%-75%" },
        { 11, "75%-80%" },
        { 12, "80%-85%" },
        { 13, "85%-90%" },
        { 14, "90%-95%" },
        { 15, "95%-99%" },
        { 16, "100%" },
        { CommonConstants.Www7timerBrokenIntValue, CommonConstants.Www7timerBrokenStringValue },
    };

    private const string twoClearDescription = "Total cloud cover less than 20%";
    private const string twoMcloudyDescription = "Total cloud cover between 20%-80%";
    private const string twoCloudyDescription = "Total cloud cover over over 80%";
    private const string twoRainDescription = "Rain with total cloud cover over 80%";
    private const string twoSnowDescription = "Snow with total cloud cover over 80%";
    private const string twoTsDescription = "Lifted Index less than -5";
    private const string twoTsRainDescription = "Lifted Index less than -5 with rain";

    private readonly Dictionary<string, string> _twoWeatherDescription = new()
    {
        { "clear", twoClearDescription },
        { "mcloudy", twoMcloudyDescription },
        { "cloudy", twoCloudyDescription },
        { "rain", twoRainDescription },
        { "snow", twoSnowDescription },
        { "ts", twoTsDescription },
        { "tsrain", twoTsRainDescription },
        { CommonConstants.Www7timerBrokenStringValue, CommonConstants.Www7timerBrokenStringValue },
    };

    #endregion

    private const string _www7timerDateFormat = "yyyyMMdd";

    public ForecastMappingProfile()
    {
        CreateMap<CivilForecast, HumanizedCivilForecastDto>()
            .ForMember(
                dest => dest.DateTime,
                opt => opt.MapFrom(
                    x => DateTime.Now.Date
                        .AddHours(x.TimePoint)
                        .ToString($"{CommonConstants.DefaultTimeFormat} {CommonConstants.DefaultDateFormat}")))
            .ForMember(dest => dest.CloudCover, opt => opt.MapFrom(x => _cloudCoverDescription[x.CloudCover]))
            .ForMember(dest => dest.PrecType, opt => opt.MapFrom(x => _precipitationTypeDescription[x.PrecType]))
            .ForMember(dest => dest.PrecAmount, opt => opt.MapFrom(x => _precipitationAmountDescription[x.PrecAmount]))
            .ForMember(dest => dest.Temperature, opt => opt.MapFrom(x => GetPrettifiedTemperature(x.Temp2m)))
            .ForMember(dest => dest.RelativeHumidity, opt => opt.MapFrom(x => x.Rh2m));

        CreateMap<CivilLightForecast, HumanizedCivilLightForecastDto>()
            .ForMember(
                dest => dest.Date,
                opt => opt.MapFrom(x => DateTime.ParseExact(
                    x.Date.ToString(),
                    _www7timerDateFormat,
                    CultureInfo.InvariantCulture)
                .ToString($"{CommonConstants.DefaultDateFormat}")))
            .ForMember(dest => dest.Weather, opt => opt.MapFrom(x => _civilWeatherDescription[x.Weather]))
            .ForMember(dest => dest.MinTemperature, opt => opt.MapFrom(x => GetPrettifiedTemperature(x.Temp2m.Min)))
            .ForMember(dest => dest.MaxTemperature, opt => opt.MapFrom(x => GetPrettifiedTemperature(x.Temp2m.Max)))
            .ForMember(dest => dest.Wind, opt => opt.MapFrom(x => _windDescription[x.WindType]));

        CreateMap<TwoWeakForecast, HumanizedTwoWeakForecastDto>()
            .ForMember(
                dest => dest.DateTime,
                opt => opt.MapFrom(
                    x => DateTime.Now.Date
                    .AddHours(x.TimePoint)
                    .ToString($"{CommonConstants.DefaultTimeFormat} {CommonConstants.DefaultDateFormat}")))
            .ForMember(dest => dest.CloudCover, opt => opt.MapFrom(x => _cloudCoverDescription[x.CloudCover]))
            .ForMember(dest => dest.RelativeHumidity, opt => opt.MapFrom(x => _relativeHumidityDescription[x.Rh2m]))
            .ForMember(dest => dest.WindDirection, opt => opt.MapFrom(x => x.Wind10m.Direction))
            .ForMember(dest => dest.WindSpeed, opt => opt.MapFrom(x => _windDescription[x.Wind10m.Speed]))
            .ForMember(dest => dest.Weather, opt => opt.MapFrom(x => _twoWeatherDescription[x.Weather])); ;
    }

    private static string GetPrettifiedTemperature(int temperature)
    {
        var retValue = (temperature > 0 ? "+" : string.Empty)
            + temperature
            + "°С";

        return retValue;
    }
}
