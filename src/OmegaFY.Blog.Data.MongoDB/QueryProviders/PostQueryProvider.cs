using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.Posts.GetAllPosts;
using OmegaFY.Blog.Application.Queries.Posts.GetMostRecentPublishedPosts;
using OmegaFY.Blog.Application.Queries.Posts.GetPost;
using OmegaFY.Blog.Application.Queries.QueryProviders.Posts;

namespace OmegaFY.Blog.Data.MongoDB.QueryProviders;

internal class PostQueryProvider : IPostQueryProvider
{
    public Task<PagedResult<GetAllPostsQueryResult>> GetAllPostsQueryResultAsync(GetAllPostsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResult<GetMostRecentPublishedPostsQueryResult>> GetMostRecentPublishedPostsQueryResultAsync(GetMostRecentPublishedPostsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<GetPostQueryResult> GetPostQueryResultAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}