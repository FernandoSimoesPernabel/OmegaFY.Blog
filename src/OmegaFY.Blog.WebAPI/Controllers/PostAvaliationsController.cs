using Microsoft.AspNetCore.Mvc;
using OmegaFY.Blog.Domain.Bus;
using OmegaFY.Blog.WebAPI.Controllers.Base;

namespace OmegaFY.Blog.WebAPI.Controllers;

[ApiVersion("1.0")]
public class PostAvaliationsController : ApiControllerBase<PostAvaliationsController>
{
    public PostAvaliationsController(ILogger<PostAvaliationsController> logger, IServiceBus serviceBus) : base(logger, serviceBus) { }
}
