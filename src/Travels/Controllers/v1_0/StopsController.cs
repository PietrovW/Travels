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
using Travels.Infrastructure.DTO;

namespace Travels.Api.Controllers.v1_0
{
    [ApiVersion("1.0")]
    public class StopsController : TravelsControllerBase
    {
        public StopsController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync(CancellationToken ct)
        {
            IEnumerable<TravelDTO> customers = await this._mediator.Send(new GetAllTravelsQuerie(), cancellationToken:ct);
            if (customers !=null )
            {
                return NoContent();
            }
            return Ok(customers);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetByIdAsync([FromQuery] GetByIdTravelsQuerie querie, CancellationToken ct)
        {
            TravelDTO customer = await this._mediator.Send(new GetByIdTravelsQuerie() { Id = querie.Id }, cancellationToken:ct);
            if (customer!=null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAsync(PutTravelsCommand todoItem, CancellationToken ct)
        {
            if (todoItem.Id != todoItem.Id)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAsync([FromBody] PostTravelsCommand invoiceModel, CancellationToken ct)
        {
            var result = await this._mediator.Send(invoiceModel);
            return CreatedAtAction(nameof(GetByIdAsync), result, result.Id);
        }

        [HttpDelete()]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
