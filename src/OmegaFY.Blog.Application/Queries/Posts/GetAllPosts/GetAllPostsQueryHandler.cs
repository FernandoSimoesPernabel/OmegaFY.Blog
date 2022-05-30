using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Application.Queries.Pagination;
using OmegaFY.Blog.Application.Queries.QueryProviders.Posts;
using OmegaFY.Blog.Infra.Authentication.Users;

namespace OmegaFY.Blog.Application.Queries.Posts.GetAllPosts;

internal class GetAllPostsQueryHandler : QueryHandlerMediatRBase<GetAllPostsQueryHandler, GetAllPostsQuery, PagedResult<GetAllPostsQueryResult>>
{
    private readonly IPostQueryProvider _postQueryProvider;

    public GetAllPostsQueryHandler(IUserInformation user, ILogger<GetAllPostsQueryHandler> logger, IPostQueryProvider postQueryProvider) : base(user, logger)
    {
        _postQueryProvider = postQueryProvider;
    }

    public override async Task<PagedResult<GetAllPostsQueryResult>> HandleAsync(GetAllPostsQuery request, CancellationToken cancellationToken)
    {
        return await _postQueryProvider.GetAllPostsQueryResultAsync(request, cancellationToken);
    }
}