using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Domain.Authentication;
using OmegaFY.Blog.Domain.Pagination;
using OmegaFY.Blog.Domain.QueryProviders.Posts;
using OmegaFY.Blog.Domain.QueryProviders.Posts.QueryResults;

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
        return await _postQueryProvider.GetAllPostsQueryResultAsync(
            request.StartDateOfCreation, 
            request.EndDateOfCreation, 
            request.AuthorId,
            request.PageNumber, 
            request.PageSize, 
            cancellationToken);
    }
}
