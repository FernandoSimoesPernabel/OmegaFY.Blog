using Microsoft.AspNetCore.Identity;

namespace OmegaFY.Blog.Infra.Authentication.Users;

public interface IUserManager
{
    public Task<bool> CheckPasswordAsync(IdentityUser<string> identityUser, string password, CancellationToken cancellationToken);

    public Task<IdentityResult> CreateAsync(IdentityUser<string> identityUser, string password, CancellationToken cancellationToken);

    public Task<IdentityUser<string>> FindByEmailAsync(string email, CancellationToken cancellationToken);
}