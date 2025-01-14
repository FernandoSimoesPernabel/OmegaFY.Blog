using OmegaFY.Blog.Domain.Entities.Posts;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Domain.Repositories.Posts;

public interface IPostRepository : IRepository<Post>
{
    public Task AddPostAsync(Post post, CancellationToken cancellationToken);

    public Task UpdatePostAsync(Post post, CancellationToken cancellationToken);

    public Task<Post> GetByIdAsync(ReferenceId postId, ReferenceId authorId, CancellationToken cancellationToken);
}