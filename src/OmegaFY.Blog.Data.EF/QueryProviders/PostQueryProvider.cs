using Microsoft.EntityFrameworkCore;
using OmegaFY.Blog.Data.EF.Context;
using OmegaFY.Blog.Domain.Pagination;
using OmegaFY.Blog.Domain.QueryProviders.Posts;
using OmegaFY.Blog.Domain.QueryProviders.Posts.QueryResults;

namespace OmegaFY.Blog.Data.EF.QueryProviders;

internal class PostQueryProvider : IPostQueryProvider
{
    private readonly QueryContext _context;

    public PostQueryProvider(QueryContext context)
    {
        _context = context;
    }

    public async Task<PagedResult<GetAllPostsQueryResult>> GetAllPostsQueryResultAsync(
        DateTime? startDateOfCreation,
        DateTime? endDateOfCreation,
        Guid? authorId,
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken)
    {
        int totalOfItens = await _context.Set<GetAllPostsQueryResult>().FromSqlInterpolated($"SELECT * FROM Posts").CountAsync(cancellationToken);

        PagedResultInfo pagedResultInfo = new PagedResultInfo(pageNumber, pageSize, totalOfItens);

        GetAllPostsQueryResult[] results = await _context.Set<GetAllPostsQueryResult>()
            .FromSqlInterpolated(@$"
                SELECT
                    Id,
                    Title,
                    AuthorId,
                    DateOfCreation

                FROM
                    Posts

                ORDER BY
                    DateOfCreation DESC

                LIMIT 
                    {pageSize} 

                OFFSET 
                    {pagedResultInfo.ItemsToSkip()}")
            .ToArrayAsync(cancellationToken);

        return new PagedResult<GetAllPostsQueryResult>(pagedResultInfo, results);
    }

    public async Task<GetPostQueryResult> GetPostQueryResultAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Set<GetPostQueryResult>()
            .FromSqlInterpolated(@$"
                SELECT 
                    Id,
                    AuthorId,
                    Title, 
                    SubTitle,
                    Content,
                    DateOfCreation,
                    DateOfModification,
                    AverageRate,
                    (SELECT COUNT(1) AS Q FROM Avaliations WHERE PostId = P.Id) AS Avaliations,
                    (SELECT COUNT(1) AS Q FROM Comments WHERE PostId = P.Id) AS Comments,
                    (SELECT COUNT(1) AS Q FROM Shares WHERE PostId = P.Id) AS Shares

                FROM 
                    Posts AS P

                WHERE 
                    Id = {id}")
            .FirstOrDefaultAsync(cancellationToken);
    }
}
