using OmegaFY.Blog.Domain.Entities.Comments;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Domain.Repositories.Comments;

public interface ICommentRepository : IRepository<PostComments>
{
    public Task<PostComments> GetPostByIdAsync(ReferenceId postId, CancellationToken cancellationToken);

    public Task UpdatePostCommentsAsync(PostComments postComments, CancellationToken cancellationToken);
}