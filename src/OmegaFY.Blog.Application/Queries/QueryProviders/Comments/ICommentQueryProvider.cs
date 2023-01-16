using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.Comments.GetComment;
using OmegaFY.Blog.Application.Queries.Comments.GetCommentsFromPostsFromPost;
using OmegaFY.Blog.Application.Queries.Comments.GetMostReactedComments;
using OmegaFY.Blog.Application.Queries.Comments.GetMostRecentComments;
using OmegaFY.Blog.Application.Queries.Comments.GetReactionsFromPost;

namespace OmegaFY.Blog.Application.Queries.QueryProviders.Comments;

public interface ICommentQueryProvider : IQueryProvider
{
    public Task<GetCommentQueryResult> GetCommentQueryResultAsync(GetCommentQuery request, CancellationToken cancellationToken);

    public Task<GetCommentsFromPostQueryResult> GetCommentsFromPostQueryResultAsync(GetCommentsFromPostQuery request, CancellationToken cancellationToken);

    public Task<PagedResult<GetMostReactedCommentsQueryResult>> GetMostReactedCommentsQueryResultAsync(GetMostReactedCommentsQuery request, CancellationToken cancellationToken);

    public Task<PagedResult<GetMostRecentCommentsQueryResult>> GetMostRecentCommentsQueryResultAsync(GetMostRecentCommentsQuery request, CancellationToken cancellationToken);

    public Task<GetReactionsFromCommentQueryResult> GetReactionsFromCommentQueryResultAsync(GetReactionsFromCommentQuery request, CancellationToken cancellationToken);
}