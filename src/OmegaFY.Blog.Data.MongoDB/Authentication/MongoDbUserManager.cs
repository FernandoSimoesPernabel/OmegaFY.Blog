using AspNetCore.Identity.Mongo.Model;
using Microsoft.AspNetCore.Identity;
using OmegaFY.Blog.Infra.Authentication.Models;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Data.MongoDB.Authentication;

internal class MongoDbUserManager : IUserManager
{
    private readonly UserManager<MongoUser<string>> _userManager;

    public MongoDbUserManager(UserManager<MongoUser<string>> userManager) => _userManager = userManager;

    public async Task<bool> CheckPasswordAsync(LoginInput loginInput, CancellationToken cancellationToken)
    {
        MongoUser<string> identityUser = await _userManager.FindByEmailAsync(loginInput.Email);

        if (identityUser is null)
            return false;

        return await _userManager.CheckPasswordAsync(identityUser, loginInput.Password);
    }

    public Task<IdentityResult> CreateAsync(LoginInput loginInput, CancellationToken cancellationToken)
    {
        MongoUser<string> identityUser = new()
        {
            Id = loginInput.UserId.ToString(),
            Email = loginInput.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = loginInput.Email
        };

        return _userManager.CreateAsync(identityUser, loginInput.Password);
    }

    public async Task<IdentityUser<string>> FindByEmailAsync(string email, CancellationToken cancellationToken) 
        => await _userManager.FindByIdAsync(email);
}