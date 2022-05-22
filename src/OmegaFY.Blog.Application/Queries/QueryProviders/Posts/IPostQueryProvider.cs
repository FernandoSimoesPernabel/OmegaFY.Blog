using OmegaFY.Blog.Application.Queries.Pagination;
using OmegaFY.Blog.Application.Queries.Posts.GetAllPosts;
using OmegaFY.Blog.Application.Queries.Posts.GetPost;

namespace OmegaFY.Blog.Application.Queries.QueryProviders.Posts;

public interface IPostQueryProvider : IQueryProvider
{
    public Task<PagedResult<GetAllPostsQueryResult>> GetAllPostsQueryResultAsync(GetAllPostsQuery request, CancellationToken cancellationToken);

    public Task<GetPostQueryResult> GetPostQueryResultAsync(Guid id, CancellationToken cancellationToken);
}