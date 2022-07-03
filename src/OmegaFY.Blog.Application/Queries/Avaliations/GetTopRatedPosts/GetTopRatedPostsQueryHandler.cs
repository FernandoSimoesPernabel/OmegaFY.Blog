using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Queries.Avaliations.GetTopRatedPosts;

internal class GetTopRatedPostsQueryHandler : QueryHandlerMediatRBase<GetTopRatedPostsQueryHandler, GetTopRatedPostsQuery, GetTopRatedPostsQueryResult>
{
    public GetTopRatedPostsQueryHandler(IUserInformation currentUser, ILogger<GetTopRatedPostsQueryHandler> logger) : base(currentUser, logger)
    {
    }

    public override async Task<GetTopRatedPostsQueryResult> HandleAsync(GetTopRatedPostsQuery request, CancellationToken cancellationToken)
    {
        return null;
    }
}
