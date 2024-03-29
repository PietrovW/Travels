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
using Travels.Infrastructure.DTO;
using Wolverine;

namespace Travels.Api.Controllers.v1_0;

[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "V1")]
public class TravelController : TravelsControllerBase
{
    public TravelController(IMessageBus bus) : base(bus)
    {

    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<TravelDTO>>> GetAllAsync(CancellationToken cancellationToken)
    {
        IEnumerable<TravelDTO> customers = await this._bus.InvokeAsync<IEnumerable<TravelDTO>>(new GetAllTravelsQuerie(), cancellation: cancellationToken);
        if (customers == null)
        {
            return NoContent();
        }
        return Ok(customers);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        var customers = await this._bus.InvokeAsync<TravelDTO>(new GetByIdTravelsQuerie() { Id = id }, cancellation: cancellationToken);
        return Ok(customers);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PutTodoItemAsync(long id, UpdateTravelsComman todoItem, CancellationToken cancellationToken)
    {
        if (todoItem.Id != todoItem.Id)
        {
            return BadRequest();
        }

        return NoContent();
    }

    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TravelDTO))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreatedAsync([FromBody] CreationTravelsCommand invoiceModel, CancellationToken cancellationToken)
    {
        var result = await this._bus.InvokeAsync<TravelDTO>(invoiceModel, cancellation: cancellationToken);
        return CreatedAtAction(nameof(GetByIdAsync), new { id = result.Id }, invoiceModel);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromQuery] DeleteTravelCommand deleteTravelCommand, CancellationToken cancellationToken)
    {
        await this._bus.InvokeAsync(new DeleteTravelCommand { Id = deleteTravelCommand.Id }, cancellation: cancellationToken);
        return NoContent();
    }
}
