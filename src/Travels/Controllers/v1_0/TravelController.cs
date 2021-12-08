using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Travels.Api.Attributes;
using Travels.Api.Controllers.Base;
using Travels.Core.Queries;
using Travels.Infrastructure.Command;
using Travels.Infrastructure.DTO;

namespace Travels.Api.Controllers.v1_0
{
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
        public async Task<TravelDTO> GetByIdAsync([FromQuery] long id)
        {
            TravelDTO customers = await this._mediator.Send(new GetByIdTravelsQuerie() { Id = id },  CancellationToken.None);
            return customers;
        }

        [HttpPut()]
        [ValidateModel]
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TravelDTO>> CreatedAsync([FromBody] PostTravelsCommand invoiceModel)
        {
            var result = await this._mediator.Send(invoiceModel, CancellationToken.None);
            return CreatedAtAction(nameof(GetByIdAsync), "Travel", new { id = result.Id }, result);
        }

        [HttpDelete()]
        [ValidateModel]
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
