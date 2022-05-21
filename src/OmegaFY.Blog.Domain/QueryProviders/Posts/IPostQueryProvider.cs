using OmegaFY.Blog.Domain.Pagination;
using OmegaFY.Blog.Domain.QueryProviders.Posts.QueryResults;

namespace OmegaFY.Blog.Domain.QueryProviders.Posts;

public interface IPostQueryProvider : IQueryProvider
{
    public Task<PagedResult<GetAllPostsQueryResult>> GetAllPostsQueryResultAsync(DateTime? startDateOfCreation, DateTime? endDateOfCreation, Guid? authorId, int pageNumber, int pageSize, CancellationToken cancellationToken);

    public Task<GetPostQueryResult> GetPostQueryResultAsync(Guid id, CancellationToken cancellationToken);
}