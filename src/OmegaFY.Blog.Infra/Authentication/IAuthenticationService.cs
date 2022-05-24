namespace OmegaFY.Blog.Infra.Authentication;

public interface IAuthenticationService
{
    public Task RegisterNewUserAsync(string email, string password, CancellationToken cancellationToken);

    public Task<string> LoginAsync(string email, string password, CancellationToken cancellationToken);
}