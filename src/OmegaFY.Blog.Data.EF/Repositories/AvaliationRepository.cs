using Microsoft.EntityFrameworkCore;
using OmegaFY.Blog.Data.EF.Context;
using OmegaFY.Blog.Data.EF.Repositories.Base;
using OmegaFY.Blog.Domain.Entities.Avaliations;
using OmegaFY.Blog.Domain.Repositories.Avaliations;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Data.EF.Repositories;

internal sealed class AvaliationRepository : BaseRepository<PostAvaliations>, IAvaliationRepository
{
    public AvaliationRepository(AvaliationsContext dbContext) : base(dbContext) { }

    public Task<PostAvaliations> GetPostByIdAsync(ReferenceId postId, CancellationToken cancellationToken)
        => _dbSet.Include(post => post.Avaliations).FirstOrDefaultAsync(post => post.Id == postId, cancellationToken);
}