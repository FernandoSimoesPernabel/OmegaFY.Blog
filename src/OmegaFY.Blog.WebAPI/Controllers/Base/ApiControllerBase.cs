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

        protected readonly IMapperServices _mapper;

        public ApiControllerBase(ILogger<TController> logger, IServiceBus serviceBus, IMapperServices mapper)
        {
            _logger = logger;
            _serviceBus = serviceBus;
            _mapper = mapper;
        }

    }

}
