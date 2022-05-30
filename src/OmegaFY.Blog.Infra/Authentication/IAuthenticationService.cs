using OmegaFY.Blog.Infra.Authentication.Configs;

namespace OmegaFY.Blog.Infra.Authentication;

public interface IAuthenticationService
{
    public Task<AuthenticationToken> RegisterNewUserAsync(LoginOptions loginOptions, CancellationToken cancellationToken);

    public Task<AuthenticationToken> LoginAsync(LoginOptions loginOptions);
}