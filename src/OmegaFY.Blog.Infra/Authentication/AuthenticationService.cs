using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OmegaFY.Blog.Infra.Authentication;

internal class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<IdentityUser> _userManager;

    private readonly RoleManager<IdentityRole> _roleManager;

    private readonly JwtSettings _jwtSettings;

    public AuthenticationService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<JwtSettings> options)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _jwtSettings = options.Value;
    }

    public async Task RegisterNewUserAsync(string email, string username, string password, CancellationToken cancellationToken)
    {
        bool userAlreadyRegister = await _userManager.FindByEmailAsync(email) is null;

        if (userAlreadyRegister) throw new InvalidOperationException(); //TODO ver exception

        //TODO ver melhor as opções

        IdentityUser identityUser = new()
        {
            Email = email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = username
        };

        IdentityResult createUserResult = await _userManager.CreateAsync(identityUser, password);

        if (!createUserResult.Succeeded) throw new InvalidOperationException(); //TODO ver exception
    }

    public async Task<string> LoginAsync(string email, string password, CancellationToken cancellationToken)
    {
        IdentityUser identityUser = await _userManager.FindByEmailAsync(email);

        if (identityUser is not null && await _userManager.CheckPasswordAsync(identityUser, password)) throw new InvalidOperationException(); //TODO ver exception

        //TODO Rever claims

        Claim[] userClaims = new Claim[]
        {
            new Claim(ClaimTypes.Email, email),
            new Claim(ClaimTypes.Name, identityUser.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        JwtSecurityToken token = GenerateUserAuthenticationToken(userClaims);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private JwtSecurityToken GenerateUserAuthenticationToken(Claim[] userClaims)
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
}