using Microsoft.EntityFrameworkCore;
using OmegaFY.Blog.Application.Queries.Avaliations.GetTopRatedPosts;
using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.QueryProviders.Avaliations;
using OmegaFY.Blog.Application.Queries.Shares.GetMostRecentShares;
using OmegaFY.Blog.Data.EF.Context;
using OmegaFY.Blog.Data.EF.Models;
using OmegaFY.Blog.Domain.Entities.Posts;

namespace OmegaFY.Blog.Data.EF.QueryProviders;

internal class AvaliationQueryProvider : IAvaliationQueryProvider
{
    private readonly QueryContext _context;

    public AvaliationQueryProvider(QueryContext context) => _context = context;

    public async Task<PagedResult<GetTopRatedPostsQueryResult>> GetTopRatedPostsQueryResultAsync(GetTopRatedPostsQuery request, CancellationToken cancellationToken)
    {
        IQueryable<PostDatabaseModel> query = _context.Set<PostDatabaseModel>().AsNoTracking()
            .OrderByDescending(post => post.AverageRate)
            .Where(post => !post.Private);

        int totalOfItens = await query.CountAsync(cancellationToken);

        PagedResultInfo pagedResultInfo = new PagedResultInfo(request.PageNumber, request.PageSize, totalOfItens);

        GetTopRatedPostsQueryResult[] result =
            await query.Select(post => new GetTopRatedPostsQueryResult()
            {
                PostId = post.Id,
                AverageRate = post.AverageRate,
                DateOfCreation = post.DateOfCreation,
                PostAuthorName = post.Author.DisplayName,
                PostTitle = post.Title
            })
            .Skip(pagedResultInfo.ItemsToSkip())
            .Take(request.PageSize)
            .ToArrayAsync(cancellationToken);

        return new PagedResult<GetTopRatedPostsQueryResult>(pagedResultInfo, result);
    }
}