using Application.Dtos.Locations;
using Application.Modules.Locations.Commands.CreateLocation;
using Application.Modules.Locations.Commands.DeleteLocation;
using Application.Modules.Locations.Commands.UpdateLocation;
using Application.Modules.Locations.Queries.GetAllLocations;
using Application.Modules.Locations.Queries.GetLocationDetails;

namespace API.Controllers;

/// <summary>
/// Locations controller.
/// </summary>
/// <seealso cref="Microsoft.AspNetApplication.Mvc.ControllerBase" />
[Route("api/locations")]
[ApiController]
public class LocationsController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="LocationsController"/> class.
    /// </summary>
    /// <param name="mediator">The mediator.</param>
    public LocationsController(IMediator mediator)
        => _mediator = mediator;

    /// <summary>
    /// Gets all locations.
    /// </summary>
    /// <returns>
    /// List of location.
    /// </returns>
    [HttpGet("")]
    [ProducesResponseType(typeof(LocationShortDto[]), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ErrorResponseDto), (int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<LocationShortDto[]>> GetAllLocationsAsync()
    {
        var queryRequest = new GetAllLocationsQueryRequest();

        var queryResult = await _mediator.Send(queryRequest);

        return Ok(queryResult.Data);
    }

    /// <summary>
    /// Gets location details.
    /// </summary>
    /// <param name="id">Location identifier.</param>
    /// <returns>
    /// Location details.
    /// </returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(LocationFullDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ErrorResponseDto), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ErrorResponseDto), (int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<LocationFullDto>> GetLocationDetailsAsync([FromRoute] Guid id)
    {
        var queryRequest = new GetLocationDetailsQueryRequest { Id = id };

        var queryResult = await _mediator.Send(queryRequest);

        return Ok(queryResult.Data);
    }

    /// <summary>
    /// Creates new location.
    /// </summary>
    /// <param name="id">Location identifier.</param>
    /// <param name="details">Location details.</param>
    /// <returns>
    /// Action result.
    /// </returns>
    [HttpPost("")]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(ErrorResponseDto), (int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult> CreateLocationAsync([FromBody] LocationDetailsDto details)
    {
        var commandRequest = new CreateLocationCommandRequest { Details = details };

        var commandResult = await _mediator.Send(commandRequest);

        return Created(new Uri(Request.Host + Request.Path + "/" + commandResult.Data.ToString()), null);
    }

    /// <summary>
    /// Updates existing location.
    /// </summary>
    /// <param name="details">Location details.</param>
    /// <returns>
    /// Action result.
    /// </returns>
    [HttpPut("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType(typeof(ErrorResponseDto), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ErrorResponseDto), (int)HttpStatusCode.NotFound)]
    public async Task<ActionResult> UpdateLocationAsync([FromRoute] Guid id, [FromBody] LocationDetailsDto details)
    {
        var commandRequest = new UpdateLocationCommandRequest
        { 
            Details = details,
            Id = id,
        };

        await _mediator.Send(commandRequest);

        return NoContent();
    }

    /// <summary>
    /// Deletes the location.
    /// </summary>
    /// <param name="id">Location identifier.</param>
    /// <returns>
    /// Action result.
    /// </returns>
    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType(typeof(ErrorResponseDto), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ErrorResponseDto), (int)HttpStatusCode.NotFound)]
    public async Task<ActionResult> DeleteLocationAsync([FromRoute] Guid id)
    {
        var commandRequest = new DeleteLocationCommandRequest { Id = id };

        await _mediator.Send(commandRequest);

        return NoContent();
    }
}
