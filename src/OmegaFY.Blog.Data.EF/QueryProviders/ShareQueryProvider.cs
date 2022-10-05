﻿using Microsoft.EntityFrameworkCore;
using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.QueryProviders.Shares;
using OmegaFY.Blog.Application.Queries.Shares.CurrentUserHasSharedPost;
using OmegaFY.Blog.Application.Queries.Shares.GetMostRecentShares;
using OmegaFY.Blog.Data.EF.Context;
using OmegaFY.Blog.Data.EF.Models;

namespace OmegaFY.Blog.Data.EF.QueryProviders;

internal class ShareQueryProvider : IShareQueryProvider
{
    private readonly QueryContext _context;

    public ShareQueryProvider(QueryContext context) => _context = context;

    public async Task<CurrentUserHasSharedPostQueryResult> CurrentUserHasSharedPostQueryResultAsync(Guid postId, Guid authorId, CancellationToken cancellationToken)
    {
        Guid? shareId = await _context.Set<SharedDatabaseModel>().AsNoTracking()
            .Where(share => share.PostId == postId && share.AuthorId == authorId)
            .Select(share => (Guid?)share.Id)
            .FirstOrDefaultAsync(cancellationToken);

        return new CurrentUserHasSharedPostQueryResult(postId, shareId);
    }

    public async Task<PagedResult<GetMostRecentSharesQueryResult>> GetMostRecentSharesQueryResultAsync(GetMostRecentSharesQuery request, CancellationToken cancellationToken)
    {
        IQueryable<SharedDatabaseModel> query = _context.Set<SharedDatabaseModel>().AsNoTracking()
            .OrderByDescending(x => x.DateAndTimeOfShare)
            .Where(share => !share.Post.Private);

        int totalOfItens = await query.CountAsync(cancellationToken);

        PagedResultInfo pagedResultInfo = new PagedResultInfo(request.PageNumber, request.PageSize, totalOfItens);

        GetMostRecentSharesQueryResult[] result =
            await query.Select(share => new GetMostRecentSharesQueryResult()
            {
                Id = share.Id,
                AuthorId = share.AuthorId,
                AuthorName = share.Author.DisplayName,
                DateAndTimeOfShare = share.DateAndTimeOfShare,
                PostId = share.PostId,
                PostSubTitle = share.Post.SubTitle,
                PostTitle = share.Post.Title
            })
            .Skip(pagedResultInfo.ItemsToSkip())
            .Take(request.PageSize)
            .ToArrayAsync(cancellationToken);

        return new PagedResult<GetMostRecentSharesQueryResult>(pagedResultInfo, result);
    }

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