using Microsoft.AspNetCore.Identity;
using OmegaFY.Blog.Infra.Authentication.Models;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Data.EF.Authentication;

internal class EntityFrameworkUserManager : IUserManager
{
    private readonly UserManager<IdentityUser<string>> _userManager;

    public EntityFrameworkUserManager(UserManager<IdentityUser<string>> userManager) => _userManager = userManager;

    public async Task<bool> CheckPasswordAsync(LoginInput loginInput, CancellationToken cancellationToken)
    {
        IdentityUser<string> identityUser = await _userManager.FindByEmailAsync(loginInput.Email);

        if (identityUser is null || !await _userManager.CheckPasswordAsync(identityUser, loginInput.Password))
            return false;

        return await _userManager.CheckPasswordAsync(identityUser, loginInput.Password);
    }

    public Task<IdentityResult> CreateAsync(LoginInput loginInput, CancellationToken cancellationToken)
    {
        IdentityUser<string> identityUser = new()
        {
            Email = loginInput.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = loginInput.Email
        };

        return _userManager.CreateAsync(identityUser, loginInput.Password);
    }

    public Task<IdentityUser<string>> FindByEmailAsync(string email, CancellationToken cancellationToken)
        => _userManager.FindByEmailAsync(email);
}