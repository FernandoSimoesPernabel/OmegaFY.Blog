using Microsoft.EntityFrameworkCore;
using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.QueryProviders.Shares;
using OmegaFY.Blog.Application.Queries.Shares.CurrentUserHasSharedPost;
using OmegaFY.Blog.Application.Queries.Shares.GetMostRecentShares;
using OmegaFY.Blog.Data.EF.Context;
using OmegaFY.Blog.Data.EF.Extensions;
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
            .OrderByDescending(share => share.DateAndTimeOfShare)
            .Where(share => !share.Post.Private);

        if (request.AuthorId.HasValue)
            query = query.Where(share => share.AuthorId == request.AuthorId.Value);

        int totalOfItens = await query.CountAsync(cancellationToken);

        PagedResultInfo pagedResultInfo = new PagedResultInfo(request.PageNumber, request.PageSize, totalOfItens);

        GetMostRecentSharesQueryResult[] result =
            await query.Select(share => new GetMostRecentSharesQueryResult()
            {
                ShareId = share.Id,
                ShareAuthorName = share.Author.DisplayName,
                DateAndTimeOfShare = share.DateAndTimeOfShare,
                PostId = share.PostId,
                PostTitle = share.Post.Title,
                PostAuthorName = share.Post.Author.DisplayName
            })
            .Paginate(pagedResultInfo)
            .ToArrayAsync(cancellationToken);

        return new PagedResult<GetMostRecentSharesQueryResult>(pagedResultInfo, result);
    }
}