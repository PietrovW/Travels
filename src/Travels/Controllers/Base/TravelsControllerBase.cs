using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Wolverine;

namespace Travels.Api.Controllers.Base;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public abstract class TravelsControllerBase : Controller
{
    internal readonly IMessageBus _bus;

    public TravelsControllerBase(IMessageBus bus):base()
    {
        _bus = bus;
    }
}
