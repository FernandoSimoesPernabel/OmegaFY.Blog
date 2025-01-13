using Microsoft.AspNetCore.Identity;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Data.EF.Authentication;

internal class EntityFrameworkUserManager : IUserManager
{
    private readonly UserManager<IdentityUser<string>> _userManager;

    public EntityFrameworkUserManager(UserManager<IdentityUser<string>> userManager) => _userManager = userManager;

    public Task<bool> CheckPasswordAsync(IdentityUser<string> identityUser, string password, CancellationToken cancellationToken)
        => _userManager.CheckPasswordAsync(identityUser, password);

    public Task<IdentityResult> CreateAsync(IdentityUser<string> identityUser, string password, CancellationToken cancellationToken)
        => _userManager.CreateAsync(identityUser, password);

    public Task<IdentityUser<string>> FindByEmailAsync(string email, CancellationToken cancellationToken)
        => _userManager.FindByEmailAsync(email);
}