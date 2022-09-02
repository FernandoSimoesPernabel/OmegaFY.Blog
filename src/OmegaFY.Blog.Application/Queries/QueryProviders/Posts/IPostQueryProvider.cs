using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.Posts.GetAllPosts;
using OmegaFY.Blog.Application.Queries.Posts.GetMostRecentPublishedPosts;
using OmegaFY.Blog.Application.Queries.Posts.GetPost;

namespace OmegaFY.Blog.Application.Queries.QueryProviders.Posts;

public interface IPostQueryProvider : IQueryProvider
{
    public Task<PagedResult<GetAllPostsQueryResult>> GetAllPostsQueryResultAsync(GetAllPostsQuery request, CancellationToken cancellationToken);

    public Task<PagedResult<GetMostRecentPublishedPostsQueryResult>> GetMostRecentPublishedPostsQueryResultAsync(GetMostRecentPublishedPostsQuery request, CancellationToken cancellationToken);

    public Task<GetPostQueryResult> GetPostQueryResultAsync(Guid id, CancellationToken cancellationToken);
}