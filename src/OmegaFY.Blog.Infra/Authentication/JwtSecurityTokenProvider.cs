using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OmegaFY.Blog.Infra.Authentication;

internal class JwtSecurityTokenProvider : IJwtProvider
{
    private readonly JwtSettings _jwtSettings;

    public JwtSecurityTokenProvider(IOptions<JwtSettings> options)
    {
        _jwtSettings = options.Value;
    }

    public JwtSecurityToken GenerateUserAuthenticationToken(Claim[] userClaims)
    {
        SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));

        JwtSecurityToken token = new JwtSecurityToken(
            issuer: _jwtSettings.ValidIssuer,
            audience: _jwtSettings.ValidAudience,
            expires: DateTime.UtcNow.AddHours(3),
            claims: userClaims,
            signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256));

        return token;
    }

    public string WriteTokenAsString(JwtSecurityToken token) => new JwtSecurityTokenHandler().WriteToken(token);
}