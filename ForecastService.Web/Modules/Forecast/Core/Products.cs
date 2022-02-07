namespace ForecastService.Web.Modules.Forecast.Core;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Products
{
    [EnumMember(Value = "civil")]
    Civil,

    [EnumMember(Value = "civillight")]
    Civillight,

    [EnumMember(Value = "two")]
    Two,
}
