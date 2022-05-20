namespace OmegaFY.Blog.Domain.Repositories;

public interface IUnitOfWork
{
    public Task SaveChangesAsync(CancellationToken cancellationToken);
}
