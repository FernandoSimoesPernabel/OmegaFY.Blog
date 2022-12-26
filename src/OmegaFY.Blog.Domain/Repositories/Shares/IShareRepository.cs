using OmegaFY.Blog.Domain.Entities.Posts;
using OmegaFY.Blog.Domain.Entities.Shares;

namespace OmegaFY.Blog.Domain.Repositories.Shares;

public interface IShareRepository : IRepository<PostShares>
{
    public Task<PostShares> GetPostByIdAsync(ReferenceId postId, CancellationToken cancellationToken);
}