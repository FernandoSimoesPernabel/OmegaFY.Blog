using OmegaFY.Blog.Domain.Entities.Posts;

namespace OmegaFY.Blog.Domain.Repositories.Posts;

public interface IPostRepository : IRepository<Post>
{
    public Task<Post> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    public Task CreatePostAsync(Post post, CancellationToken cancellationToken);
}