using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OmegaFY.Blog.Application.Bus;

namespace OmegaFY.Blog.WebAPI.Controllers.Base;

[ApiController]
[ApiConventionType(typeof(DefaultApiConventions))]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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