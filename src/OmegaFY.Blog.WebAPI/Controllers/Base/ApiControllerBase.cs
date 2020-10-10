using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Domain.Core.Services;

namespace OmegaFY.Blog.WebAPI.Controllers.Base
{

    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    //[Authorize]
    [Route("api/[controller]/")]
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

}
