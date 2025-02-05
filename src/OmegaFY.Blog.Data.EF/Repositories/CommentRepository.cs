using Microsoft.EntityFrameworkCore;
using OmegaFY.Blog.Data.EF.Context;
using OmegaFY.Blog.Data.EF.Repositories.Base;
using OmegaFY.Blog.Domain.Entities.Comments;
using OmegaFY.Blog.Domain.Repositories.Comments;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Data.EF.Repositories;

internal sealed class CommentRepository : BaseRepository<PostComments>, ICommentRepository
{
    public CommentRepository(CommentsContext dbContext) : base(dbContext) { }

    public Task<PostComments> GetPostByIdAsync(ReferenceId postId, CancellationToken cancellationToken)
        => _dbSet.Include(post => post.Comments).ThenInclude(comment => comment.Reactions).AsSplitQuery().FirstOrDefaultAsync(post => post.Id == postId, cancellationToken);

    public Task UpdatePostCommentsAsync(PostComments postComments, CancellationToken cancellationToken) => Task.CompletedTask;
}