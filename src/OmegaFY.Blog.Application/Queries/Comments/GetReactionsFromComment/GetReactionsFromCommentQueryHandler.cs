using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Infra.Authentication.Users;
using OmegaFY.Blog.Application.Queries.QueryProviders.Comments;

namespace OmegaFY.Blog.Application.Queries.Comments.GetReactionsFromComment;

internal sealed class GetReactionsFromCommentQueryHandler : QueryHandlerMediatRBase<GetReactionsFromCommentQueryHandler, GetReactionsFromCommentQuery, GetReactionsFromCommentQueryResult>
{
    private readonly ICommentQueryProvider _commentQueryProvider;

    public GetReactionsFromCommentQueryHandler(IUserInformation currentUser, ILogger<GetReactionsFromCommentQueryHandler> logger, ICommentQueryProvider commentQueryProvider)
        : base(currentUser, logger) => _commentQueryProvider = commentQueryProvider;

    public override Task<GetReactionsFromCommentQueryResult> HandleAsync(GetReactionsFromCommentQuery request, CancellationToken cancellationToken)
        => _commentQueryProvider.GetReactionsFromCommentQueryResultAsync(request, cancellationToken);
}