using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Queries.Comments.GetCommentsFromPostsFromPost;

internal class GetCommentsFromPostQueryHandler : QueryHandlerMediatRBase<GetCommentsFromPostQueryHandler, GetCommentsFromPostQuery, PagedResult<GetCommentsFromPostQueryResult>>
{
    public GetCommentsFromPostQueryHandler(IUserInformation currentUser, ILogger<GetCommentsFromPostQueryHandler> logger) : base(currentUser, logger)
    {
    }

    public override Task<PagedResult<GetCommentsFromPostQueryResult>> HandleAsync(GetCommentsFromPostQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}