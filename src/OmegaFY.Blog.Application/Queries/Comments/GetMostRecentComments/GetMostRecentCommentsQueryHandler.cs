using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Queries.Comments.GetMostRecentComments;

internal class GetMostRecentCommentsQueryHandler : QueryHandlerMediatRBase<GetMostRecentCommentsQueryHandler, GetMostRecentCommentsQuery, GetMostRecentCommentsQueryResult>
{
    public GetMostRecentCommentsQueryHandler(IUserInformation currentUser, ILogger<GetMostRecentCommentsQueryHandler> logger) : base(currentUser, logger)
    {
    }

    public override async Task<GetMostRecentCommentsQueryResult> HandleAsync(GetMostRecentCommentsQuery request, CancellationToken cancellationToken)
    {
        return null;
    }
}
