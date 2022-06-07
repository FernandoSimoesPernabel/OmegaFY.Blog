using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OmegaFY.Blog.Infra.Authentication.Configs;
using OmegaFY.Blog.Infra.Authentication.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OmegaFY.Blog.Infra.Authentication.Token;

internal class JwtSecurityTokenProvider : IJwtProvider
{
    private readonly JwtSettings _jwtSettings;

    public JwtSecurityTokenProvider(IOptions<JwtSettings> options) => _jwtSettings = options.Value;

    public AuthenticationToken RefreshToken(string currentToken)
    {
        throw new NotImplementedException();
    }

    public AuthenticationToken WriteToken(LoginInput loginOptions)
    {
        DateTimeOffset utcNow = DateTimeOffset.UtcNow;

        long issuedAt = utcNow.ToUnixTimeSeconds();

        long expiresInUnixTimeInSeconds = utcNow.Add(_jwtSettings.TimeToExpireToken).ToUnixTimeSeconds();

        DateTime tokenExpiresIn = DateTimeOffset.FromUnixTimeSeconds(expiresInUnixTimeInSeconds).UtcDateTime;

        DateTime refreshExpiresIn = tokenExpiresIn.Add(_jwtSettings.TimeToExpireRefreshToken);

        Claim[] userClaims = new Claim[]
        {
            new Claim(JwtRegisteredClaimNames.Aud, _jwtSettings.Audience),
            new Claim(JwtRegisteredClaimNames.Iss, _jwtSettings.Issuer),
            new Claim(JwtRegisteredClaimNames.Sub, loginOptions.UserId.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, loginOptions.Email),
            new Claim(JwtRegisteredClaimNames.Name, loginOptions.UserName),
            new Claim(JwtRegisteredClaimNames.Exp, expiresInUnixTimeInSeconds.ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, issuedAt.ToString()),
            new Claim(JwtRegisteredClaimNames.Nbf, issuedAt.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        JwtSecurityToken token = new JwtSecurityToken(
            claims: userClaims,
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature));

        return new AuthenticationToken(new JwtSecurityTokenHandler().WriteToken(token), tokenExpiresIn, refreshExpiresIn);
    }
}