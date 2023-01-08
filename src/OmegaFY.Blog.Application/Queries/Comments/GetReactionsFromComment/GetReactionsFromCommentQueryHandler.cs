using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Queries.Comments.GetReactionsFromPost;

internal class GetReactionsFromCommentQueryHandler : QueryHandlerMediatRBase<GetReactionsFromCommentQueryHandler, GetReactionsFromCommentQuery, PagedResult<GetReactionsFromCommentQueryResult>>
{
    public GetReactionsFromCommentQueryHandler(IUserInformation currentUser, ILogger<GetReactionsFromCommentQueryHandler> logger) : base(currentUser, logger)
    {
    }

    public override Task<PagedResult<GetReactionsFromCommentQueryResult>> HandleAsync(GetReactionsFromCommentQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}