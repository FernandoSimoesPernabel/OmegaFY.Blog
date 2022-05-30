using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OmegaFY.Blog.Infra.Authentication.Configs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OmegaFY.Blog.Infra.Authentication.Token;

internal class JwtSecurityTokenProvider : IJwtProvider
{
    private readonly JwtSettings _jwtSettings;

    public JwtSecurityTokenProvider(IOptions<JwtSettings> options) => _jwtSettings = options.Value;

    public AuthenticationToken WriteToken(LoginOptions loginOptions)
    {
        JwtSecurityToken jwtSecurityToken = GenerateUserAuthenticationToken(loginOptions);
        return new AuthenticationToken(new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken));
    }

    private JwtSecurityToken GenerateUserAuthenticationToken(LoginOptions loginOptions)
    {
        long issuedAt = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        long expiresInUnixTimeInSeconds = DateTimeOffset.UtcNow.Add(_jwtSettings.TimeToExpire).ToUnixTimeSeconds();

        DateTime expiresIn = DateTimeOffset.FromUnixTimeSeconds(expiresInUnixTimeInSeconds).UtcDateTime;

        Claim[] userClaims = new Claim[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, loginOptions.UserId.ToString()),
            new Claim(JwtRegisteredClaimNames.Iss, _jwtSettings.Issuer),
            new Claim(JwtRegisteredClaimNames.Exp, expiresInUnixTimeInSeconds.ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, issuedAt.ToString()),
            new Claim(JwtRegisteredClaimNames.Aud, _jwtSettings.Audience),
            new Claim(JwtRegisteredClaimNames.Email, loginOptions.Email),
            new Claim(JwtRegisteredClaimNames.Name, loginOptions.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        JwtSecurityToken token = new JwtSecurityToken(
            issuer: _jwtSettings.ValidIssuer,
            audience: _jwtSettings.ValidAudience,
            expires: expiresIn,
            claims: userClaims,
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature));

        return token;
    }
}