using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.Shares.CurrentUserHasSharedPost;
using OmegaFY.Blog.Application.Queries.Shares.GetMostRecentShares;

namespace OmegaFY.Blog.Application.Queries.QueryProviders.Shares;

public interface IShareQueryProvider : IQueryProvider
{
    public Task<CurrentUserHasSharedPostQueryResult> CurrentUserHasSharedPostQueryResultAsync(Guid postId, Guid authorId, CancellationToken cancellationToken);

    public Task<PagedResult<GetMostRecentSharesQueryResult>> GetMostRecentSharesQueryResultAsync(GetMostRecentSharesQuery request, CancellationToken cancellationToken);
}