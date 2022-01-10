using Core.Dtos.Locations;
using Core.Modules.Locations.CreateLocation;
using Core.Modules.Locations.DeleteLocation;
using Core.Modules.Locations.GetAllLocations;
using Core.Modules.Locations.GetLocationDetails;
using Core.Modules.Locations.UpdateLocation;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;

/// <summary>
/// Locations controller.
/// </summary>
/// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
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
        var request = new GetAllLocationsRequest();

        var result = await _mediator.Send(request);

        return Ok(result.Data);
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
        var request = new GetLocationDetailsRequest { Id = id };

        var result = await _mediator.Send(request);

        return Ok(result.Data);
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
        var request = new CreateLocationRequest { Details = details };

        var result = await _mediator.Send(request);

        return Created(new Uri(Request.Host + Request.Path + "/" + result.Data.ToString()), null);
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
        var request = new UpdateLocationRequest
        { 
            Details = details,
            Id = id,
        };

        await _mediator.Send(request);

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
        var request = new DeleteLocationRequest { Id = id };

        await _mediator.Send(request);

        return NoContent();
    }
}
