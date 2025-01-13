using Microsoft.AspNetCore.Identity;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Data.MongoDB.Authentication;

internal class MongoDbUserManager : IUserManager
{
    private readonly IUserStore<IdentityUser> _userStore;

    private readonly IUserPasswordStore<IdentityUser> _passwordStore;

    public MongoDbUserManager(IUserStore<IdentityUser> userStore, IUserPasswordStore<IdentityUser> passwordStore)
    {
        _userStore = userStore;
        _passwordStore = passwordStore;
    }

    public async Task<bool> CheckPasswordAsync(IdentityUser identityUser, string password, CancellationToken cancellationToken)
    {
        bool hasPassword = await _passwordStore.HasPasswordAsync(identityUser, cancellationToken);

        string passwordHash = await _passwordStore.GetPasswordHashAsync(identityUser, cancellationToken);
        
        return hasPassword && passwordHash == password;
    }

    public async Task<IdentityResult> CreateAsync(IdentityUser identityUser, string password, CancellationToken cancellationToken)
    {
        await _userStore.CreateAsync(identityUser, cancellationToken);

        await _passwordStore.SetPasswordHashAsync(identityUser, password, cancellationToken);

        return IdentityResult.Success;
    }

    public Task<IdentityUser> FindByEmailAsync(string email, CancellationToken cancellationToken) => _userStore.FindByNameAsync(email, cancellationToken);
}