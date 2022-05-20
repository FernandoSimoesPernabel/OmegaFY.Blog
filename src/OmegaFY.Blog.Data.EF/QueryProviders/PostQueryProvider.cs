using Microsoft.EntityFrameworkCore;
using OmegaFY.Blog.Data.EF.Context;
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
