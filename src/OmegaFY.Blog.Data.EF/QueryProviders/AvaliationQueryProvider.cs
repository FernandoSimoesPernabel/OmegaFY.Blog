using Microsoft.EntityFrameworkCore;
using OmegaFY.Blog.Application.Queries.Avaliations.GetAvaliationsFromPost;
using OmegaFY.Blog.Application.Queries.Avaliations.GetMostRecentAvaliations;
using OmegaFY.Blog.Application.Queries.Avaliations.GetTopRatedPosts;
using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.QueryProviders.Avaliations;
using OmegaFY.Blog.Data.EF.Context;
using OmegaFY.Blog.Data.EF.Extensions;
using OmegaFY.Blog.Data.EF.Models;

namespace OmegaFY.Blog.Data.EF.QueryProviders;

internal class AvaliationQueryProvider : IAvaliationQueryProvider
{
    private readonly QueryContext _context;

    public AvaliationQueryProvider(QueryContext context) => _context = context;

    public async Task<GetAvaliationsFromPostQueryResult> GetAvaliationsFromPostQueryResultAsync(GetAvaliationsFromPostQuery request, CancellationToken cancellationToken)
    {
        AvaliationFromPost[] result = await _context.Set<AvaliationDatabaseModel>()
            .OrderByDescending(avaliation => avaliation.DateOfModification ?? avaliation.DateOfCreation)
            .Where(avaliation => !avaliation.Post.Private)
            .Select(avaliation => new AvaliationFromPost()
            {
                AvaliationId = avaliation.Id,
                AuthorId = avaliation.AuthorId,
                AuthorName = avaliation.Author.DisplayName,
                AvaliationDate = avaliation.DateOfModification ?? avaliation.DateOfCreation,
                HasAvaliationBeenEdit = avaliation.DateOfModification.HasValue,
                PostId = avaliation.PostId,
                PostTitle = avaliation.Post.Title,
                Rate = avaliation.Rate
            }).ToArrayAsync(cancellationToken);

        return new GetAvaliationsFromPostQueryResult(result);
    }

    public async Task<PagedResult<GetMostRecentAvaliationsQueryResult>> GetMostRecentAvaliationsQueryResultAsync(GetMostRecentAvaliationsQuery request, CancellationToken cancellationToken)
    {
        IQueryable<AvaliationDatabaseModel> query = _context.Set<AvaliationDatabaseModel>()
            .OrderByDescending(avaliation => avaliation.DateOfModification ?? avaliation.DateOfCreation)
            .Where(avaliation => !avaliation.Post.Private);

        int totalOfItems = await query.CountAsync(cancellationToken);

        PagedResultInfo pagedResultInfo = new PagedResultInfo(request.PageNumber, request.PageSize, totalOfItems);

        GetMostRecentAvaliationsQueryResult[] result =
            await query.Select(avaliation => new GetMostRecentAvaliationsQueryResult()
            {
                AvaliationId = avaliation.Id,
                AuthorId = avaliation.AuthorId,
                AuthorName = avaliation.Author.DisplayName,
                AvaliationDate = avaliation.DateOfModification ?? avaliation.DateOfCreation,
                HasAvaliationBeenEdit = avaliation.DateOfModification.HasValue,
                PostId = avaliation.PostId,
                PostTitle = avaliation.Post.Title,
                Rate = avaliation.Rate
            })
            .Paginate(pagedResultInfo)
            .ToArrayAsync(cancellationToken);

        return new PagedResult<GetMostRecentAvaliationsQueryResult>(pagedResultInfo, result);
    }

    public async Task<PagedResult<GetTopRatedPostsQueryResult>> GetTopRatedPostsQueryResultAsync(GetTopRatedPostsQuery request, CancellationToken cancellationToken)
    {
        IQueryable<PostDatabaseModel> query = _context.Set<PostDatabaseModel>().AsNoTracking()
            .OrderByDescending(post => post.AverageRate)
            .Where(post => !post.Private);

        int totalOfItems = await query.CountAsync(cancellationToken);

        PagedResultInfo pagedResultInfo = new PagedResultInfo(request.PageNumber, request.PageSize, totalOfItems);

        GetTopRatedPostsQueryResult[] result =
            await query.Select(post => new GetTopRatedPostsQueryResult()
            {
                PostId = post.Id,
                AuthorId = post.AuthorId,
                AverageRate = post.AverageRate,
                DateOfCreation = post.DateOfCreation,
                PostAuthorName = post.Author.DisplayName,
                PostTitle = post.Title
            })
            .Paginate(pagedResultInfo)
            .ToArrayAsync(cancellationToken);

        return new PagedResult<GetTopRatedPostsQueryResult>(pagedResultInfo, result);
    }
}