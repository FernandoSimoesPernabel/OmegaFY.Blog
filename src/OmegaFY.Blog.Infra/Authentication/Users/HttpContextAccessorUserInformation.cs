using Microsoft.AspNetCore.Http;
using OmegaFY.Blog.Infra.Exceptions;
using System.Security.Claims;

namespace OmegaFY.Blog.Infra.Authentication.Users;

internal class HttpContextAccessorUserInformation : IUserInformation
{
    public Guid? CurrentRequestUserId { get; }

    public string Email { get; }

    public HttpContextAccessorUserInformation(IHttpContextAccessor httpContextAccessor)
    {
        if (httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
        {
            if (!Guid.TryParse(httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value, out Guid userId))
                throw new UnauthorizedException();

            string email = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            if (string.IsNullOrWhiteSpace(email))
                throw new UnauthorizedException();

            CurrentRequestUserId = userId;
            Email = email;
        }
    }
}