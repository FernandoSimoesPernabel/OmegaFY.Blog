using Microsoft.AspNetCore.Http;
using OmegaFY.Blog.Common.Exceptions;
using OmegaFY.Blog.Infra.Extensions;
using System.Security.Claims;

namespace OmegaFY.Blog.Infra.Authentication.Users;

internal class HttpContextAccessorUserInformation : IUserInformation
{
    public Guid? CurrentRequestUserId { get; }

    public string Email { get; }

    public HttpContextAccessorUserInformation(IHttpContextAccessor httpContextAccessor)
    {
        if (httpContextAccessor.HttpContext.User.IsAuthenticated())
        {
            Guid? userId = httpContextAccessor.HttpContext.User.TryGetUserIdFromClaims();

            if (userId is null)
                throw new UnauthorizedException();

            string email = httpContextAccessor.HttpContext.User.TryGetEmailFromClaims();

            if (string.IsNullOrWhiteSpace(email))
                throw new UnauthorizedException();

            CurrentRequestUserId = userId;
            Email = email;
        }
    }
}