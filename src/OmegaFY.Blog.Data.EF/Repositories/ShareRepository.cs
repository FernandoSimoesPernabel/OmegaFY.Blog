using Microsoft.EntityFrameworkCore;
using OmegaFY.Blog.Data.EF.Repositories.Base;
using OmegaFY.Blog.Domain.Entities.Shares;
using OmegaFY.Blog.Domain.Repositories.Posts;
using OmegaFY.Blog.Domain.Repositories.Shares;

namespace OmegaFY.Blog.Data.EF.Repositories;

internal class ShareRepository : BaseRepository<PostShares>, IShareRepository
{
    public ShareRepository(DbContext dbContext) : base(dbContext)
    {
    }
}