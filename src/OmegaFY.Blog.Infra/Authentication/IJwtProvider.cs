using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OmegaFY.Blog.Infra.Authentication;

public interface IJwtProvider
{
    public JwtSecurityToken GenerateUserAuthenticationToken(Claim[] userClaims);

    public string WriteTokenAsString(JwtSecurityToken token);
}
