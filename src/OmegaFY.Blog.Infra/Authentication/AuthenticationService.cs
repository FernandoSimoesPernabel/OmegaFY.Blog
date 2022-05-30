using Microsoft.AspNetCore.Identity;
using OmegaFY.Blog.Infra.Authentication.Configs;
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

    public async Task<AuthenticationToken> RegisterNewUserAsync(LoginOptions loginOptions, CancellationToken cancellationToken)
    {
        bool userAlreadyRegister = await _userManager.FindByEmailAsync(loginOptions.Email) is not null;

        if (userAlreadyRegister) throw new InvalidOperationException(); //TODO ver exception

        IdentityUser identityUser = new()
        {
            Email = loginOptions.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = loginOptions.Email
        };

        IdentityResult createUserResult = await _userManager.CreateAsync(identityUser, loginOptions.Password);

        if (!createUserResult.Succeeded) throw new InvalidOperationException(); //TODO ver exception

        return await LoginAsync(loginOptions);
    }

    public async Task<AuthenticationToken> LoginAsync(LoginOptions loginOptions)
    {
        IdentityUser identityUser = await _userManager.FindByEmailAsync(loginOptions.Email);

        if (identityUser is not null && !await _userManager.CheckPasswordAsync(identityUser, loginOptions.Password)) throw new InvalidOperationException(); //TODO ver exception

        return _jwtProvider.WriteToken(loginOptions);
    }
}