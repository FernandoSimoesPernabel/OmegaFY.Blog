﻿using Microsoft.EntityFrameworkCore;
using OmegaFY.Blog.Application.Queries.Posts.GetPost;
using OmegaFY.Blog.Application.Queries.QueryProviders.Shares;
using OmegaFY.Blog.Application.Queries.Shares.GetMostRecentShares;
using OmegaFY.Blog.Data.EF.Context;
using OmegaFY.Blog.Data.EF.Models;

namespace OmegaFY.Blog.Data.EF.QueryProviders;

internal class ShareQueryProvider : IShareQueryProvider
{
    private readonly QueryContext _context;

    public ShareQueryProvider(QueryContext context) => _context = context;

    public async Task<GetShareQueryResult> GetShareQueryResultAsync(Guid shareId, Guid authorId, CancellationToken cancellationToken)
    {
        return await _context.Set<SharedDatabaseModel>().AsNoTracking()
            .Where(share => share.Id == shareId && share.AuthorId == authorId)
            .Select(share => new GetShareQueryResult()
            {
                Id = share.Id,
                AuthorId = share.Author.Id,
                AuthorName = share.Author.DisplayName,
                DateAndTimeOfShare = share.DateAndTimeOfShare,
                PostId = share.PostId
            }).FirstOrDefaultAsync(cancellationToken);
    }
}