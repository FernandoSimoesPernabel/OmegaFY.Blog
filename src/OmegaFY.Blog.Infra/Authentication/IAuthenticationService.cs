namespace OmegaFY.Blog.Infra.Authentication;

public interface IAuthenticationService
{
    public Task RegisterNewUserAsync(string email, string username, string password, CancellationToken cancellationToken);

    public Task<string> LoginAsync(string emaik, string password, CancellationToken cancellationToken);
}