using Microsoft.AspNetCore.Identity;
using OmegaFY.Blog.Infra.Authentication.Models;

namespace OmegaFY.Blog.Infra.Authentication.Users;

public interface IUserManager
{
    public Task<bool> CheckPasswordAsync(LoginInput loginInput, CancellationToken cancellationToken);

    public Task<IdentityResult> CreateAsync(LoginInput loginInput, CancellationToken cancellationToken);

    public Task<IdentityUser<string>> FindByEmailAsync(string email, CancellationToken cancellationToken);
}