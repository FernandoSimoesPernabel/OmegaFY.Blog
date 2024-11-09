using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Infra.Authentication.Users;
using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Queries.QueryProviders.Comments;

namespace OmegaFY.Blog.Application.Queries.Comments.GetComment;

internal sealed class GetCommentQueryHandler : QueryHandlerMediatRBase<GetCommentQueryHandler, GetCommentQuery, GetCommentQueryResult>
{
    private readonly ICommentQueryProvider _commentQueryProvider;

    public GetCommentQueryHandler(IUserInformation currentUser, ILogger<GetCommentQueryHandler> logger, ICommentQueryProvider commentQueryProvider)
        : base(currentUser, logger) => _commentQueryProvider = commentQueryProvider;

    public override Task<GetCommentQueryResult> HandleAsync(GetCommentQuery request, CancellationToken cancellationToken)
        => _commentQueryProvider.GetCommentQueryResultAsync(request, cancellationToken);
}