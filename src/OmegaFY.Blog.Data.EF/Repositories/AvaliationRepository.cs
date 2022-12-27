using Microsoft.EntityFrameworkCore;
using OmegaFY.Blog.Data.EF.Context;
using OmegaFY.Blog.Data.EF.Repositories.Base;
using OmegaFY.Blog.Domain.Entities.Avaliations;
using OmegaFY.Blog.Domain.Repositories.Avaliations;

namespace OmegaFY.Blog.Data.EF.Repositories;

internal class AvaliationRepository : BaseRepository<PostAvaliations>, IAvaliationRepository
{
    public AvaliationRepository(AvaliationsContext dbContext) : base(dbContext) { }

    public async Task<PostAvaliations> GetPostByIdAsync(ReferenceId postId, CancellationToken cancellationToken)
        => await _dbSet.Include(post => post.Avaliations).FirstOrDefaultAsync(post => post.Id == postId, cancellationToken);
}