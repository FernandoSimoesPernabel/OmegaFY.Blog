using OmegaFY.Blog.Infra.Authentication.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OmegaFY.Blog.Infra.Authentication.Token;

internal interface IJwtProvider
{
    public AuthenticationToken RefreshToken(AuthenticationToken currentToken, RefreshTokenInput refreshTokenInput);

    public AuthenticationToken WriteToken(LoginInput loginOptions);

    public AuthenticationToken WriteToken(Guid userId, string email, string username);
}