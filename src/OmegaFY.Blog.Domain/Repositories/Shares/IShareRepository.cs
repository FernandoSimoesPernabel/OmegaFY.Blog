﻿using OmegaFY.Blog.Domain.Entities.Shares;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Domain.Repositories.Shares;

public interface IShareRepository : IRepository<PostShares>
{
    public Task<PostShares> GetPostByIdAsync(ReferenceId postId, CancellationToken cancellationToken);

    public Task UpdatePostShares(PostShares postShares, CancellationToken cancellationToken);
}