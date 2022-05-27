using OmegaFY.Blog.Infra.Authentication.Configs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OmegaFY.Blog.Infra.Authentication;

public interface IJwtProvider
{
    public AuthenticationToken WriteToken(LoginOptions loginOptions);
}
