using Microsoft.AspNetCore.Mvc;
using OmegaFY.Blog.Domain.Bus;
using OmegaFY.Blog.WebAPI.Controllers.Base;

namespace OmegaFY.Blog.WebAPI.Controllers;

[ApiVersion("1.0")]
public class PostSharesController : ApiControllerBase<PostSharesController>
{
    public PostSharesController(ILogger<PostSharesController> logger, IServiceBus serviceBus) : base(logger, serviceBus) { }
}
