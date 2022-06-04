using OmegaFY.Blog.Infra.Authentication.Models;

namespace OmegaFY.Blog.Infra.Authentication;

public interface IAuthenticationService
{
    public Task<AuthenticationToken> RegisterNewUserAsync(LoginInput loginOptions, CancellationToken cancellationToken);

    public Task<AuthenticationToken> LoginAsync(LoginInput loginOptions);
}