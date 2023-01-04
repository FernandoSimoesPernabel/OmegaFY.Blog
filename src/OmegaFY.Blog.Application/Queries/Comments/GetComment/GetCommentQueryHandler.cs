using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Infra.Authentication.Users;
using Microsoft.Extensions.Logging;

namespace OmegaFY.Blog.Application.Queries.Comments.GetComment;

internal class GetCommentQueryHandler : QueryHandlerMediatRBase<GetCommentQueryHandler, GetCommentQuery, PagedResult<GetCommentQueryResult>>
{
    public GetCommentQueryHandler(IUserInformation currentUser, ILogger<GetCommentQueryHandler> logger) : base(currentUser, logger)
    {
    }

    public override Task<PagedResult<GetCommentQueryResult>> HandleAsync(GetCommentQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}