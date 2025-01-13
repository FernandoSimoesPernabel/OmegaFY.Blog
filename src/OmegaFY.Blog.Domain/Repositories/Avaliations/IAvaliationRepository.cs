using OmegaFY.Blog.Domain.Entities.Avaliations;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Domain.Repositories.Avaliations;

public interface IAvaliationRepository : IRepository<PostAvaliations>
{
    public Task<PostAvaliations> GetPostByIdAsync(ReferenceId postId, CancellationToken cancellationToken);
}