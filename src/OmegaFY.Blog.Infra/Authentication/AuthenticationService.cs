using Microsoft.AspNetCore.Identity;
using OmegaFY.Blog.Common.Exceptions;
using OmegaFY.Blog.Infra.Authentication.Models;
using OmegaFY.Blog.Infra.Authentication.Token;
using OmegaFY.Blog.Infra.Authentication.Users;
using OmegaFY.Blog.Infra.Exceptions;

namespace OmegaFY.Blog.Infra.Authentication;

internal sealed class AuthenticationService : IAuthenticationService
{
    private readonly IUserManager _userManager;

    private readonly IJwtProvider _jwtProvider;

    public AuthenticationService(IUserManager userManager, IJwtProvider jwtProvider)
    {
        _userManager = userManager;
        _jwtProvider = jwtProvider;
    }

    public async Task<AuthenticationToken> RegisterNewUserAsync(LoginInput loginInput, CancellationToken cancellationToken)
    {
        bool userAlreadyRegister = await _userManager.FindByEmailAsync(loginInput.Email, cancellationToken) is not null;

        if (userAlreadyRegister)
            throw new ConflictedException();

        IdentityUser identityUser = new()
        {
            Email = loginInput.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = loginInput.Email
        };

        IdentityResult createUserResult = await _userManager.CreateAsync(identityUser, loginInput.Password, cancellationToken);

        if (!createUserResult.Succeeded)
            throw new UnableToCreateUserOnIdentityException();

        return await LoginAsync(loginInput, cancellationToken);
    }

    public async Task<AuthenticationToken> LoginAsync(LoginInput loginInput, CancellationToken cancellationToken)
    {
        IdentityUser identityUser = await _userManager.FindByEmailAsync(loginInput.Email, cancellationToken);

        if (identityUser is null || !await _userManager.CheckPasswordAsync(identityUser, loginInput.Password, cancellationToken))
            throw new UnauthorizedException();

        return _jwtProvider.WriteToken(loginInput);
    }

    public async Task<AuthenticationToken> RefreshTokenAsync(AuthenticationToken currentToken, RefreshTokenInput refreshTokenInput, CancellationToken cancellationToken)
    {
        IdentityUser identityUser = await _userManager.FindByEmailAsync(refreshTokenInput.Email, cancellationToken);

        if (identityUser is null)
            throw new UnauthorizedException();

        return _jwtProvider.RefreshToken(currentToken, refreshTokenInput);
    }
}