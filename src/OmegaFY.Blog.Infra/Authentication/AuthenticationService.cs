using Microsoft.AspNetCore.Identity;
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

    public async Task RegisterNewUserAsync(string email, string password, CancellationToken cancellationToken)
    {
        bool userAlreadyRegister = await _userManager.FindByEmailAsync(email) is not null;

        if (userAlreadyRegister) throw new InvalidOperationException(); //TODO ver exception

        //TODO ver melhor as opções

        IdentityUser identityUser = new()
        {
            Email = email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = email
        };

        IdentityResult createUserResult = await _userManager.CreateAsync(identityUser, password);

        if (!createUserResult.Succeeded) throw new InvalidOperationException(); //TODO ver exception
    }

    public async Task<string> LoginAsync(string email, string password, CancellationToken cancellationToken)
    {
        IdentityUser identityUser = await _userManager.FindByEmailAsync(email);

        if (identityUser is not null && !await _userManager.CheckPasswordAsync(identityUser, password)) throw new InvalidOperationException(); //TODO ver exception

        //TODO Rever claims

        Claim[] userClaims = new Claim[]
        {
            new Claim(ClaimTypes.Email, identityUser.Email),
            new Claim(ClaimTypes.Name, identityUser.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        return _jwtProvider.WriteTokenAsString(_jwtProvider.GenerateUserAuthenticationToken(userClaims));
    }
}