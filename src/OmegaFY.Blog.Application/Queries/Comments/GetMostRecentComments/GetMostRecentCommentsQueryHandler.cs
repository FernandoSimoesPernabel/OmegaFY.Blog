using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.QueryProviders.Comments;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Queries.Comments.GetMostRecentComments;

internal sealed class GetMostRecentCommentsQueryHandler : QueryHandlerMediatRBase<GetMostRecentCommentsQueryHandler, GetMostRecentCommentsQuery, PagedResult<GetMostRecentCommentsQueryResult>>
{
    private readonly ICommentQueryProvider _commentQueryProvider;

    public GetMostRecentCommentsQueryHandler(IUserInformation currentUser, ILogger<GetMostRecentCommentsQueryHandler> logger, ICommentQueryProvider commentQueryProvider)
        : base(currentUser, logger) => _commentQueryProvider = commentQueryProvider;

    public override Task<PagedResult<GetMostRecentCommentsQueryResult>> HandleAsync(GetMostRecentCommentsQuery request, CancellationToken cancellationToken)
        => _commentQueryProvider.GetMostRecentCommentsQueryResultAsync(request, cancellationToken);
}
