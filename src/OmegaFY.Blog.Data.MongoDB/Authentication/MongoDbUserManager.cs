using AspNetCore.Identity.Mongo.Model;
using Microsoft.AspNetCore.Identity;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Data.MongoDB.Authentication;

internal class MongoDbUserManager : IUserManager
{
    private readonly IUserStore<MongoUser<string>> _userStore;

    private readonly IUserPasswordStore<MongoUser<string>> _passwordStore;

    public MongoDbUserManager(IUserStore<MongoUser<string>> userStore, IUserPasswordStore<MongoUser<string>> passwordStore)
    {
        _userStore = userStore;
        _passwordStore = passwordStore;
    }

    public async Task<bool> CheckPasswordAsync(IdentityUser<string> identityUser, string password, CancellationToken cancellationToken)
    {
        MongoUser<string> mongoIdentityUser = identityUser as MongoUser<string>;

        bool hasPassword = await _passwordStore.HasPasswordAsync(mongoIdentityUser, cancellationToken);

        string passwordHash = await _passwordStore.GetPasswordHashAsync(mongoIdentityUser, cancellationToken);
        
        return hasPassword && passwordHash == password;
    }

    public async Task<IdentityResult> CreateAsync(IdentityUser<string> identityUser, string password, CancellationToken cancellationToken)
    {
        MongoUser<string> mongoIdentityUser = identityUser as MongoUser<string>;

        await _userStore.CreateAsync(mongoIdentityUser, cancellationToken);

        await _passwordStore.SetPasswordHashAsync(mongoIdentityUser, password, cancellationToken);

        return IdentityResult.Success;
    }

    public async Task<IdentityUser<string>> FindByEmailAsync(string email, CancellationToken cancellationToken) 
        => await _userStore.FindByNameAsync(email, cancellationToken);
}