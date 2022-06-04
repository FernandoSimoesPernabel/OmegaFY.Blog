using OmegaFY.Blog.Infra.Authentication.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OmegaFY.Blog.Infra.Authentication.Token;

public interface IJwtProvider
{
    public AuthenticationToken WriteToken(LoginInput loginOptions);
}
