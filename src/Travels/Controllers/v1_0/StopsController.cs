using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using Travels.Api.Controllers.Base;
using Travels.Domain.Travel.V1.Commands;
using Travels.Domain.Travel.V1.Queries;
using Travels.Domin.V1.Command;
using Travels.Infrastructure.DTO;
using Wolverine;

namespace Travels.Api.Controllers.v1_0;

[ApiVersion("1.0")]
public class StopsController : TravelsControllerBase
{
    public StopsController(IMessageBus bus) : base(bus)
    {

    }

    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var customers = await this._bus.InvokeAsync<IEnumerable<TravelDTO>>(new GetAllTravelsQuerie(), cancellation: cancellationToken);
        if (customers !=null )
        {
            return NoContent();
        }
        return Ok(customers);
    }

    [HttpGet("{querie}")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetByIdAsync([FromQuery] GetByIdTravelsQuerie querie, CancellationToken cancellationToken)
    {
        TravelDTO customer = await this._bus.InvokeAsync<TravelDTO>(new GetByIdTravelsQuerie() { Id = querie.Id }, cancellation: cancellationToken);
        if (customer != null)
        {
            return NotFound();
        }
        return Ok(customer);
    }

    [HttpPut]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> PutAsync(PutStopsCommand todoItem, CancellationToken cancellationToken)
    {
        if (todoItem.Id != todoItem.Id)
        {
            return BadRequest();
        }

        return NoContent();
    }

    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> PostAsync([FromBody] CreationStopsCommand invoiceModel, CancellationToken cancellationToken)
    {
        var result = await this._bus.InvokeAsync<long>(invoiceModel, cancellation: cancellationToken);
        return CreatedAtAction(nameof(GetByIdAsync), result, result);
    }

    [HttpDelete]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete([FromQuery] DeleteTravelCommand deleteTravelCommand, CancellationToken cancellationToken)
    {
        await this._bus.InvokeAsync(new DeleteTravelCommand { Id = deleteTravelCommand.Id }, cancellation: cancellationToken);

        return NoContent();
    }
}
