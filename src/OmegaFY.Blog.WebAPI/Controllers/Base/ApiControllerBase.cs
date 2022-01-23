using Microsoft.AspNetCore.Mvc;
using OmegaFY.Blog.Domain.Bus;

namespace OmegaFY.Blog.WebAPI.Controllers.Base;

[ApiController]
[ApiConventionType(typeof(DefaultApiConventions))]
//[Authorize]
[Route("api/[controller]")]
public abstract class ApiControllerBase<TController> : ControllerBase
{
    protected readonly ILogger<TController> _logger;

    protected readonly IServiceBus _serviceBus;

    public ApiControllerBase(ILogger<TController> logger, IServiceBus serviceBus)
    {
        _logger = logger;
        _serviceBus = serviceBus;
    }
}