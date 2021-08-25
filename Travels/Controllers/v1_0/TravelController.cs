using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travels.Api.Controllers.Base;
using Travels.Core.Domain;
using Travels.Infrastructure.Command;
using Travels.Infrastructure.Queries;

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
        public async Task<IActionResult> GetAll()
        {
            IList<ITravel> customers = await this._mediator.Send(new GetAllTravelsQuerie());
            if (customers.Any())
            {
                return NoContent();
            }
            return Ok(customers);
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetById([FromQuery] GetByIdTravelsQuerie querie)
        {
            IList<ITravel> customers = await this._mediator.Send(new GetByIdTravelsQuerie() { Id = querie.Id });
            if (customers.Any())
            {
                return NotFound();
            }
            return Ok(customers);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Created([FromBody] CreateTravelsCommand invoiceModel)
        {
            // CreateInvoiceCommand command = mapper.Map<InvoiceModel, CreateInvoiceCommand>(invoiceModel);

            var result = await this._mediator.Send(invoiceModel);
            return CreatedAtAction(nameof(GetById), result, result.Id);
        }

        [HttpDelete()]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromQuery] DeleteTravelCommand deleteTravelCommand)
        {

           Unit result = await _mediator.Send(new DeleteTravelCommand { Id = deleteTravelCommand.Id });
        
            return NoContent();
        }
    }
}
