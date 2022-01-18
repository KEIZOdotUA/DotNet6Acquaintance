using Application.Interfaces;
using Application.Modules.Weather.Queries.GetForecast;
using Domain.Enums.Www7timer;

namespace API.Controllers;

/// <summary>
/// Weather controller.
/// </summary>
/// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
[Route("api/weather")]
[ApiController]
public class WeatherController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="WeatherController"/> class.
    /// </summary>
    /// <param name="mediator">The mediator.</param>
    public WeatherController(IMediator mediator)
        => _mediator = mediator;

    /// <summary>
    /// Gets the forecast for location.
    /// </summary>
    /// <param name="locationId">The location identifier.</param>
    /// <param name="type">Forecast type.</param>
    /// <returns>
    /// Weather forecast.
    /// </returns>
    [HttpGet("{locationId}/{type}")]
    [ProducesResponseType(typeof(object), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ErrorResponseDto), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ErrorResponseDto), (int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<IHumanizedForecast[]>> GetForecast([FromRoute] Guid locationId, [FromRoute] Products type)
    {
        var queryRequest = new GetForecastQueryRequest { LocationId = locationId, Type = type };

        var queryResult = await _mediator.Send(queryRequest);

        return Ok(queryResult.Data);
    }
}
