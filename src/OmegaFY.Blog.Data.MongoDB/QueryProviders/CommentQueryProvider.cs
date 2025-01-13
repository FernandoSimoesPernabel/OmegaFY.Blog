using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.Comments.GetComment;
using OmegaFY.Blog.Application.Queries.Comments.GetCommentsFromPost;
using OmegaFY.Blog.Application.Queries.Comments.GetMostReactedComments;
using OmegaFY.Blog.Application.Queries.Comments.GetMostRecentComments;
using OmegaFY.Blog.Application.Queries.Comments.GetReactionsFromComment;
using OmegaFY.Blog.Application.Queries.QueryProviders.Comments;

namespace OmegaFY.Blog.Data.MongoDB.QueryProviders;

internal class CommentQueryProvider : ICommentQueryProvider
{
    public Task<GetCommentQueryResult> GetCommentQueryResultAsync(GetCommentQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<GetCommentsFromPostQueryResult> GetCommentsFromPostQueryResultAsync(GetCommentsFromPostQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResult<GetMostReactedCommentsQueryResult>> GetMostReactedCommentsQueryResultAsync(GetMostReactedCommentsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResult<GetMostRecentCommentsQueryResult>> GetMostRecentCommentsQueryResultAsync(GetMostRecentCommentsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<GetReactionsFromCommentQueryResult> GetReactionsFromCommentQueryResultAsync(GetReactionsFromCommentQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}