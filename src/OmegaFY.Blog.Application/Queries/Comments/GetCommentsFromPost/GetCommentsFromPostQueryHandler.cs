using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Infra.Authentication.Users;
using OmegaFY.Blog.Application.Queries.QueryProviders.Comments;

namespace OmegaFY.Blog.Application.Queries.Comments.GetCommentsFromPostsFromPost;

internal class GetCommentsFromPostQueryHandler : QueryHandlerMediatRBase<GetCommentsFromPostQueryHandler, GetCommentsFromPostQuery, GetCommentsFromPostQueryResult>
{
    private readonly ICommentQueryProvider _commentQueryProvider;

    public GetCommentsFromPostQueryHandler(IUserInformation currentUser, ILogger<GetCommentsFromPostQueryHandler> logger, ICommentQueryProvider commentQueryProvider) : base(currentUser, logger) 
        => _commentQueryProvider = commentQueryProvider;

    public override async Task<GetCommentsFromPostQueryResult> HandleAsync(GetCommentsFromPostQuery request, CancellationToken cancellationToken) 
        => await _commentQueryProvider.GetCommentsFromPostQueryResultAsync(request, cancellationToken);
}