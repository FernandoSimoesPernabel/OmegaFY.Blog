using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.QueryProviders.Shares;
using OmegaFY.Blog.Application.Queries.Shares.CurrentUserHasSharedPost;
using OmegaFY.Blog.Application.Queries.Shares.GetMostRecentShares;

namespace OmegaFY.Blog.Data.MongoDB.QueryProviders;

internal class ShareQueryProvider : IShareQueryProvider
{
    public Task<CurrentUserHasSharedPostQueryResult> CurrentUserHasSharedPostQueryResultAsync(Guid postId, Guid authorId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResult<GetMostRecentSharesQueryResult>> GetMostRecentSharesQueryResultAsync(GetMostRecentSharesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}