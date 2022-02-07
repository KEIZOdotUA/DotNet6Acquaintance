namespace WeatherService.Web.Modules.Forecast.Core;

/// <summary>
/// 7Timer! products.
/// </summary>
public enum Products
{
    /// <summary>
    /// Display the forecasted weather condition for the next 8 days.
    /// </summary>
    [EnumMember(Value = "civil")]
    Civil,

    /// <summary>
    /// Simplfied version of CIVIL which only provide 7-day forecast on a day-to-day basis.
    /// </summary>
    [EnumMember(Value = "civillight")]
    Civillight,

    /// <summary>
    /// Two-Week-Overview (TWO) is intended for civil users.
    /// It will display the forecasted weather condition for the next 9-16 days.
    /// </summary>
    [EnumMember(Value = "two")]
    Two,
}
