using Microsoft.EntityFrameworkCore;
using OmegaFY.Blog.Data.EF.Context;
using OmegaFY.Blog.Data.EF.Repositories.Base;
using OmegaFY.Blog.Domain.Entities.Shares;
using OmegaFY.Blog.Domain.Repositories.Shares;

namespace OmegaFY.Blog.Data.EF.Repositories;

internal class ShareRepository : BaseRepository<PostShares>, IShareRepository
{
    public ShareRepository(SharesContext dbContext) : base(dbContext) { }

    public async Task<PostShares> GetPostByIdAsync(Guid postId, CancellationToken cancellationToken)
        => await _dbSet.Include(post => post.Shareds).FirstOrDefaultAsync(post => post.Id == postId, cancellationToken);
}