namespace WeatherService.Web.Modules.Forecast.Adapters;

/// <summary>
/// Get forecast query request.
/// </summary>
/// <seealso cref="IRequest&lt;Application.Dtos.Common.BaseResponseDto&lt;Application.Interfaces.IHumanizedForecast[]&gt;&gt;" />
public class GetForecastQueryRequest : IRequest<IHumanizedForecast[]>
{
    /// <summary>
    /// Gets or sets the location identifier.
    /// </summary>
    /// <value>
    /// The location identifier.
    /// </value>
    public Guid LocationId { get; init; }

    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    /// <value>
    /// Product type.
    /// </value>
    public Products Type { get; init; }
}
