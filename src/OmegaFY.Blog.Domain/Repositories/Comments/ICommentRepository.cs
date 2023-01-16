using OmegaFY.Blog.Domain.Entities.Comments;

namespace OmegaFY.Blog.Domain.Repositories.Comments;

public interface ICommentRepository : IRepository<PostComments>
{
    public Task<PostComments> GetPostByIdAsync(ReferenceId postId, CancellationToken cancellationToken);
}