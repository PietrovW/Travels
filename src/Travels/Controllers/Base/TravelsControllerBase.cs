﻿using Microsoft.AspNetCore.Mvc;
using Wolverine;

namespace Travels.Api.Controllers.Base;

[ApiController]
public abstract class TravelsControllerBase : Controller
{
    internal readonly IMessageBus _bus;

    public TravelsControllerBase(IMessageBus bus):base()
    {
        _bus = bus;
    }
}
