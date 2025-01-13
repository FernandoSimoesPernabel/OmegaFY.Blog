﻿using Microsoft.AspNetCore.Identity;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Data.EF.Authentication;

internal class EntityFrameworkUserManager : IUserManager
{
    private readonly UserManager<IdentityUser> _userManager;

    public EntityFrameworkUserManager(UserManager<IdentityUser> userManager) => _userManager = userManager;

    public Task<bool> CheckPasswordAsync(IdentityUser identityUser, string password, CancellationToken cancellationToken)
        => _userManager.CheckPasswordAsync(identityUser, password);

    public Task<IdentityResult> CreateAsync(IdentityUser identityUser, string password, CancellationToken cancellationToken)
        => _userManager.CreateAsync(identityUser, password);

    public Task<IdentityUser> FindByEmailAsync(string email, CancellationToken cancellationToken)
        => _userManager.FindByEmailAsync(email);
}