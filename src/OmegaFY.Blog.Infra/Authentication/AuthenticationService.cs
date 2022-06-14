using Microsoft.AspNetCore.Identity;
using OmegaFY.Blog.Infra.Authentication.Models;
using OmegaFY.Blog.Infra.Authentication.Token;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OmegaFY.Blog.Infra.Authentication;

internal class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<IdentityUser> _userManager;

    private readonly IJwtProvider _jwtProvider;

    public AuthenticationService(UserManager<IdentityUser> userManager, IJwtProvider jwtProvider)
    {
        _userManager = userManager;
        _jwtProvider = jwtProvider;
    }

    public async Task<AuthenticationToken> RegisterNewUserAsync(LoginInput loginInput, CancellationToken cancellationToken)
    {
        bool userAlreadyRegister = await _userManager.FindByEmailAsync(loginInput.Email) is not null;

        if (userAlreadyRegister) throw new InvalidOperationException(); //TODO ver exception

        IdentityUser identityUser = new()
        {
            Email = loginInput.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = loginInput.Email
        };

        IdentityResult createUserResult = await _userManager.CreateAsync(identityUser, loginInput.Password);

        if (!createUserResult.Succeeded) throw new InvalidOperationException(); //TODO ver exception

        return await LoginAsync(loginInput);
    }

    public async Task<AuthenticationToken> LoginAsync(LoginInput loginInput)
    {
        IdentityUser identityUser = await _userManager.FindByEmailAsync(loginInput.Email);

        if (identityUser is null || !await _userManager.CheckPasswordAsync(identityUser, loginInput.Password)) throw new InvalidOperationException(); //TODO ver exception

        return _jwtProvider.WriteToken(loginInput);
    }

    public async Task<AuthenticationToken> RefreshTokenAsync(AuthenticationToken currentToken, RefreshTokenInput refreshTokenInput)
    {
        IdentityUser identityUser = await _userManager.FindByEmailAsync(refreshTokenInput.Email);

        if (identityUser is null) throw new InvalidOperationException(); //TODO ver exception

        return _jwtProvider.RefreshToken(currentToken, refreshTokenInput);
    }
}