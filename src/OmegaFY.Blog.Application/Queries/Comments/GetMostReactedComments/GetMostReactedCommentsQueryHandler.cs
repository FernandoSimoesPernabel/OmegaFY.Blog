using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Queries.Comments.GetMostReactedComments;

internal class GetMostReactedCommentsQueryHandler : QueryHandlerMediatRBase<GetMostReactedCommentsQueryHandler, GetMostReactedCommentsQuery, GetMostReactedCommentsQueryResult>
{
    public GetMostReactedCommentsQueryHandler(IUserInformation currentUser, ILogger<GetMostReactedCommentsQueryHandler> logger) : base(currentUser, logger)
    {
    }

    public override async Task<GetMostReactedCommentsQueryResult> HandleAsync(GetMostReactedCommentsQuery request, CancellationToken cancellationToken)
    {
        return null;
    }
}
