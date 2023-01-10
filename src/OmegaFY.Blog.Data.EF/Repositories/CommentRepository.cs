using Microsoft.EntityFrameworkCore;
using OmegaFY.Blog.Data.EF.Context;
using OmegaFY.Blog.Data.EF.Repositories.Base;
using OmegaFY.Blog.Domain.Entities.Avaliations;
using OmegaFY.Blog.Domain.Entities.Comments;
using OmegaFY.Blog.Domain.Repositories.Comments;

namespace OmegaFY.Blog.Data.EF.Repositories;

internal class CommentRepository : BaseRepository<PostComments>, ICommentRepository
{
    public CommentRepository(CommentsContext dbContext) : base(dbContext) { }

    public async Task<PostComments> GetPostByIdAsync(ReferenceId postId, CancellationToken cancellationToken)
        => await _dbSet.Include(post => post.Comments).FirstOrDefaultAsync(post => post.Id == postId, cancellationToken);
}