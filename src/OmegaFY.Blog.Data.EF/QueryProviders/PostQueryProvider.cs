using Microsoft.EntityFrameworkCore;
using OmegaFY.Blog.Application.Queries.Pagination;
using OmegaFY.Blog.Application.Queries.Posts.GetAllPosts;
using OmegaFY.Blog.Application.Queries.Posts.GetPost;
using OmegaFY.Blog.Application.Queries.QueryProviders.Posts;
using OmegaFY.Blog.Data.EF.Context;

namespace OmegaFY.Blog.Data.EF.QueryProviders;

internal class PostQueryProvider : IPostQueryProvider
{
    private readonly QueryContext _context;

    public PostQueryProvider(QueryContext context)
    {
        _context = context;
    }

    public async Task<PagedResult<GetAllPostsQueryResult>> GetAllPostsQueryResultAsync(GetAllPostsQuery request, CancellationToken cancellationToken)
    {
        //TODO mapear para classes e usar LINQ

        int totalOfItens = await _context.Set<GetAllPostsQueryResult>().FromSqlInterpolated($"SELECT * FROM Posts").CountAsync(cancellationToken);

        PagedResultInfo pagedResultInfo = new PagedResultInfo(request.PageNumber, request.PageSize, totalOfItens);

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
                    {request.PageSize} 

                OFFSET 
                    {pagedResultInfo.ItemsToSkip()}")
            .ToArrayAsync(cancellationToken);

        return new PagedResult<GetAllPostsQueryResult>(pagedResultInfo, results);
    }

    public async Task<GetPostQueryResult> GetPostQueryResultAsync(Guid id, CancellationToken cancellationToken)
    {
        //TODO mapear para classes e usar LINQ

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
