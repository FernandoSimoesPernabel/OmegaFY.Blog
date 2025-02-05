using Microsoft.EntityFrameworkCore;
using OmegaFY.Blog.Data.EF.Context;
using OmegaFY.Blog.Data.EF.Repositories.Base;
using OmegaFY.Blog.Domain.Entities.Shares;
using OmegaFY.Blog.Domain.Repositories.Shares;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Data.EF.Repositories;

internal sealed class ShareRepository : BaseRepository<PostShares>, IShareRepository
{
    public ShareRepository(SharesContext dbContext) : base(dbContext) { }

    public Task<PostShares> GetPostByIdAsync(ReferenceId postId, CancellationToken cancellationToken)
        => _dbSet.Include(post => post.Shareds).FirstOrDefaultAsync(post => post.Id == postId, cancellationToken);

    public Task UpdatePostShares(PostShares postShares, CancellationToken cancellationToken) => Task.CompletedTask;
}