using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.QueryProviders.Comments;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Queries.Comments.GetMostReactedComments;

internal class GetMostReactedCommentsQueryHandler : QueryHandlerMediatRBase<GetMostReactedCommentsQueryHandler, GetMostReactedCommentsQuery, PagedResult<GetMostReactedCommentsQueryResult>>
{
    private readonly ICommentQueryProvider _commentQueryProvider;

    public GetMostReactedCommentsQueryHandler(IUserInformation currentUser, ILogger<GetMostReactedCommentsQueryHandler> logger, ICommentQueryProvider commentQueryProvider) 
        : base(currentUser, logger) => _commentQueryProvider = commentQueryProvider;

    public override async Task<PagedResult<GetMostReactedCommentsQueryResult>> HandleAsync(GetMostReactedCommentsQuery request, CancellationToken cancellationToken) 
        => await _commentQueryProvider.GetMostReactedCommentsQueryResultAsync(request, cancellationToken);
}
