using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Queries.Posts.GetMostRecentPublishedPosts;

internal class GetMostRecentPublishedPostsQueryHandler : QueryHandlerMediatRBase<GetMostRecentPublishedPostsQueryHandler, GetMostRecentPublishedPostsQuery, GetMostRecentPublishedPostsQueryResult>
{
    public GetMostRecentPublishedPostsQueryHandler(IUserInformation currentUser, ILogger<GetMostRecentPublishedPostsQueryHandler> logger) : base(currentUser, logger)
    {
    }

    public override async Task<GetMostRecentPublishedPostsQueryResult> HandleAsync(GetMostRecentPublishedPostsQuery request, CancellationToken cancellationToken)
    {
        return null;
    }
}
