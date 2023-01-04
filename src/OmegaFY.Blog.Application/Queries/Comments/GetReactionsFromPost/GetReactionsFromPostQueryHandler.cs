using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Queries.Comments.GetReactionsFromPost;

internal class GetReactionsFromPostQueryHandler : QueryHandlerMediatRBase<GetReactionsFromPostQueryHandler, GetReactionsFromPostQuery, PagedResult<GetReactionsFromPostQueryResult>>
{
    public GetReactionsFromPostQueryHandler(IUserInformation currentUser, ILogger<GetReactionsFromPostQueryHandler> logger) : base(currentUser, logger)
    {
    }

    public override Task<PagedResult<GetReactionsFromPostQueryResult>> HandleAsync(GetReactionsFromPostQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}