using OmegaFY.Blog.Infra.Authentication.Models;

namespace OmegaFY.Blog.Infra.Authentication;

public interface IAuthenticationService
{
    public Task<AuthenticationToken> RefreshTokenAsync(AuthenticationToken currentToken, RefreshTokenInput refreshTokenInput);

    public Task<AuthenticationToken> RegisterNewUserAsync(LoginInput loginInput, CancellationToken cancellationToken);

    public Task<AuthenticationToken> LoginAsync(LoginInput loginInput);
}