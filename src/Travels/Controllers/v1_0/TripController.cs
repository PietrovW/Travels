using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Travels.Api.Controllers.Base;
using Travels.Domain.Travel.V1.Queries;
using Travels.Domain.Trip.V1.Commands;
using Travels.Infrastructure.DTO;
using Wolverine;

namespace Travels.Api.Controllers.v1_0;

[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "V1")]
public class TripController : TravelsControllerBase
{
    public TripController(IMessageBus bus) : base(bus)
    {

    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var customers = await this._bus.InvokeAsync<IEnumerable<TravelDTO>>(new GetAllTravelsQuerie(), cancellation: cancellationToken);
        if (customers!=null)
        {
            return NoContent();
        }
        return Ok(customers);
    }


    [HttpGet("{querie}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetByIdAsync([FromQuery] GetByIdTravelsQuerie querie, CancellationToken cancellationToken)
    {
        var customer = await this._bus.InvokeAsync<TravelDTO>(querie, cancellation: cancellationToken);
        if (customer != null)
        {
            return NotFound();
        }
        return Ok(customer);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PutAsync([FromBody] PutTripCommand putTripCommand, CancellationToken cancellationToken)
    {
        if (putTripCommand.Id != putTripCommand.Id)
        {
            return BadRequest();
        }

        return NoContent();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> PostAsync([FromBody] CreationTripCommand creationTripCommand, CancellationToken cancellationToken)
    {
        await _bus.InvokeAsync(message: creationTripCommand, cancellation: cancellationToken);
        return CreatedAtAction(nameof(GetByIdAsync), new { id =1 }, creationTripCommand);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete([FromQuery] DeleteTripCommand deleteTravelCommand, CancellationToken cancellationToken)
    {
        await this._bus.InvokeAsync(new DeleteTripCommand { Id = deleteTravelCommand.Id },cancellation: cancellationToken);
        return NoContent();
    }
}
