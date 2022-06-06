using Microsoft.AspNetCore.Http;
using OmegaFY.Blog.Infra.Exceptions;
using System.Security.Claims;

namespace OmegaFY.Blog.Infra.Authentication.Users;

internal class HttpContextAccessorUserInformation : IUserInformation
{
    public Guid? CurrentRequestUserId { get; }

    public HttpContextAccessorUserInformation(IHttpContextAccessor httpContextAccessor)
    {
        if (httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
        {
            if (!Guid.TryParse(httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value, out Guid result))
                throw new UnauthorizedException();

            CurrentRequestUserId = result;
        }
    }
}