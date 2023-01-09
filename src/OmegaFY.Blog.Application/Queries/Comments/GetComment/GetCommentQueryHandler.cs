using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Infra.Authentication.Users;
using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Queries.QueryProviders.Comments;

namespace OmegaFY.Blog.Application.Queries.Comments.GetComment;

internal class GetCommentQueryHandler : QueryHandlerMediatRBase<GetCommentQueryHandler, GetCommentQuery, GetCommentQueryResult>
{
    private readonly ICommentQueryProvider _commentQueryProvider;

    public GetCommentQueryHandler(IUserInformation currentUser, ILogger<GetCommentQueryHandler> logger, ICommentQueryProvider commentQueryProvider)
        : base(currentUser, logger) => _commentQueryProvider = commentQueryProvider;

    public override async Task<GetCommentQueryResult> HandleAsync(GetCommentQuery request, CancellationToken cancellationToken)
        => await _commentQueryProvider.GetCommentQueryResultAsync(request, cancellationToken);
}