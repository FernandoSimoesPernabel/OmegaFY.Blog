using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OmegaFY.Blog.Common.Exceptions;
using OmegaFY.Blog.Infra.Authentication.Configs;
using OmegaFY.Blog.Infra.Authentication.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OmegaFY.Blog.Infra.Authentication.Token;

internal class JwtSecurityTokenProvider : IJwtProvider
{
    private readonly JwtSettings _jwtSettings;

    private readonly TokenValidationParameters _tokenValidationParameters;

    public JwtSecurityTokenProvider(IOptions<JwtSettings> options, TokenValidationParameters tokenValidationParameters)
    {
        _jwtSettings = options.Value;
        _tokenValidationParameters = tokenValidationParameters;
    }

    public AuthenticationToken RefreshToken(AuthenticationToken currentToken, RefreshTokenInput refreshTokenInput)
    {
        ClaimsPrincipal claims = new JwtSecurityTokenHandler().ValidateToken(currentToken.Token, _tokenValidationParameters, out SecurityToken securityToken);

        if (claims is null)
            throw new UnauthorizedException();

        if (!(securityToken is JwtSecurityToken jwtSecurityToken && jwtSecurityToken.Header.Alg == SecurityAlgorithms.HmacSha256Signature))
            throw new UnauthorizedException();

        if (currentToken.RefreshTokenExpirationDate < DateTime.UtcNow)
            throw new UnauthorizedException();

        return WriteToken(refreshTokenInput.UserId, refreshTokenInput.Email, refreshTokenInput.UserName);
    }

    public AuthenticationToken WriteToken(LoginInput loginInput) => WriteToken(loginInput.UserId, loginInput.Email, loginInput.UserName);

    public AuthenticationToken WriteToken(Guid userId, string email, string username)
    {
        DateTimeOffset utcNow = DateTimeOffset.UtcNow;

        long issuedAt = utcNow.ToUnixTimeSeconds();

        long expiresInUnixTimeInSeconds = utcNow.Add(_jwtSettings.TimeToExpireToken).ToUnixTimeSeconds();

        DateTime tokenExpiresIn = DateTimeOffset.FromUnixTimeSeconds(expiresInUnixTimeInSeconds).UtcDateTime;

        DateTime refreshExpiresIn = tokenExpiresIn.Add(_jwtSettings.TimeToExpireRefreshToken);

        Claim[] userClaims =
        [
            new Claim(JwtRegisteredClaimNames.Aud, _jwtSettings.Audience),
            new Claim(JwtRegisteredClaimNames.Iss, _jwtSettings.Issuer),
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim(JwtRegisteredClaimNames.Name, username),
            new Claim(JwtRegisteredClaimNames.Exp, expiresInUnixTimeInSeconds.ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, issuedAt.ToString()),
            new Claim(JwtRegisteredClaimNames.Nbf, issuedAt.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        ];

        JwtSecurityToken token = new JwtSecurityToken(
            claims: userClaims,
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature));

        return new AuthenticationToken(new JwtSecurityTokenHandler().WriteToken(token), tokenExpiresIn, refreshExpiresIn);
    }
}