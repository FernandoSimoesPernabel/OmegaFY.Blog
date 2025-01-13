﻿using Microsoft.AspNetCore.Identity;

namespace OmegaFY.Blog.Infra.Authentication.Users;

public interface IUserManager
{
    public Task<bool> CheckPasswordAsync(IdentityUser identityUser, string password, CancellationToken cancellationToken);

    public Task<IdentityResult> CreateAsync(IdentityUser identityUser, string password, CancellationToken cancellationToken);

    public Task<IdentityUser> FindByEmailAsync(string email, CancellationToken cancellationToken);
}