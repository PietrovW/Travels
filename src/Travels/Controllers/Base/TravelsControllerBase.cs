using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Travels.Api.Controllers.Base
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class TravelsControllerBase : Controller
    {
        internal readonly IMediator _mediator;

        public TravelsControllerBase(IMediator mediator):base()
        {
            _mediator = mediator;
        }
    }
}
