using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OmegaFY.Blog.Application.Bus;
using OmegaFY.Blog.Infra.Authentication.Policies;

namespace OmegaFY.Blog.WebAPI.Controllers.Base;

[ApiController]
[ApiConventionType(typeof(DefaultApiConventions))]
[Authorize(PoliciesNamesConstants.BEARER_JWT_POLICY)]
[Route("api/[controller]/[action]")]
public abstract class ApiControllerBase : ControllerBase
{
    protected readonly IServiceBus _serviceBus;

    public ApiControllerBase(IServiceBus serviceBus) => _serviceBus = serviceBus;
}