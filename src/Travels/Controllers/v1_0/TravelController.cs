using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Travels.Api.Attributes;
using Travels.Api.Controllers.Base;
using Travels.Core.Domain;
using Travels.Core.Queries;
using Travels.Infrastructure.Command;

namespace Travels.Api.Controllers.v1_0
{
    public class TravelController : TravelsControllerBase
    {
        public TravelController(IMediator mediator):base(mediator)
        {

        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllAsync(CancellationToken ct)
        {
            IList<ITravel> customers = await this._mediator.Send(new GetAllTravelsQuerie(), ct);
            if (customers.Any())
            {
                return NoContent();
            }
            return Ok(customers);
        }

        
        [HttpGet("{id}")]
        [ValidateModel]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken ct)
        {
            IAsyncEnumerable<ITravel> customers = await this._mediator.Send(new GetByIdTravelsQuerie() { Id = id }, cancellationToken: ct);
            if (customers != null)
            {
                return NotFound();
            }
            return Ok(customers);
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
        [ValidateModel]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatedAsync([FromBody] PostTravelsCommand invoiceModel, CancellationToken ct)
        {
            // CreateInvoiceCommand command = mapper.Map<InvoiceModel, CreateInvoiceCommand>(invoiceModel);

            var result = await this._mediator.Send(invoiceModel, cancellationToken:ct);
            return CreatedAtAction(nameof(GetByIdAsync), result, result.Id);
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
