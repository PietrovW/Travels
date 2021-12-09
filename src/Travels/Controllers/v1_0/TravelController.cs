using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Travels.Api.Attributes;
using Travels.Api.Controllers.Base;
using Travels.Core.Queries;
using Travels.Infrastructure.Command;
using Travels.Infrastructure.DTO;

namespace Travels.Api.Controllers.v1_0
{
    [ApiVersion("1.0")]
    public class TravelController : TravelsControllerBase
    {
        public TravelController(IMediator mediator):base(mediator)
        {

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<TravelDTO>>> GetAllAsync(CancellationToken ct)
        {
            IEnumerable<TravelDTO> customers = await this._mediator.Send(new GetAllTravelsQuerie(), ct);
            if (customers==null)
            {
                return NoContent();
            }
            return Ok(customers);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            TravelDTO customers = await this._mediator.Send(new GetByIdTravelsQuerie() { Id = id },  CancellationToken.None);
            return Ok(customers);
        }

        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutTodoItemAsync(long id,PutTravelsCommand todoItem, CancellationToken ct)
        {
            if (todoItem.Id != todoItem.Id)
            {
                return BadRequest();
            }

           // _context.Entry(todoItem).State = EntityState.Modified;
            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TravelDTO))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatedAsync([FromBody] PostTravelsCommand invoiceModel)
        {
            TravelDTO result = await this._mediator.Send(invoiceModel, CancellationToken.None);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = result.Id }, invoiceModel);
        }

        [HttpDelete()]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromQuery] DeleteTravelCommand deleteTravelCommand)
        {

           Unit result = await _mediator.Send(new DeleteTravelCommand { Id = deleteTravelCommand.Id });
        
            if (result == Unit.Value)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
