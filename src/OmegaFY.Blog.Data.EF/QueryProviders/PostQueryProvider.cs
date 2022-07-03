using Microsoft.EntityFrameworkCore;
using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.Posts.GetAllPosts;
using OmegaFY.Blog.Application.Queries.Posts.GetPost;
using OmegaFY.Blog.Application.Queries.QueryProviders.Posts;
using OmegaFY.Blog.Data.EF.Context;
using OmegaFY.Blog.Data.EF.Models;

namespace OmegaFY.Blog.Data.EF.QueryProviders;

internal class PostQueryProvider : IPostQueryProvider
{
    private readonly QueryContext _context;

    public PostQueryProvider(QueryContext context) => _context = context;

    public async Task<PagedResult<GetAllPostsQueryResult>> GetAllPostsQueryResultAsync(GetAllPostsQuery request, CancellationToken cancellationToken)
    {
        IQueryable<PostDatabaseModel> query = _context.Set<PostDatabaseModel>().AsNoTracking();

        if (request.StartDateOfCreation.HasValue && request.EndDateOfCreation.HasValue)
            query = query.Where(x => x.DateOfCreation >= request.StartDateOfCreation.Value && x.DateOfCreation <= request.EndDateOfCreation.Value);

        if (request.AuthorId.HasValue)
            query = query.Where(x => x.Author.Id == request.AuthorId.Value);

        int totalOfItens = await query.CountAsync(cancellationToken);

        PagedResultInfo pagedResultInfo = new PagedResultInfo(request.PageNumber, request.PageSize, totalOfItens);

        GetAllPostsQueryResult[] result =
            await query.Select(x => new GetAllPostsQueryResult()
            {
                Id = x.Id,
                AverageRate = x.AverageRate,
                AuthorId = x.Author.Id,
                AuthorName = x.Author.DisplayName,
                DateOfCreation = x.DateOfCreation,
                Title = x.Title
            })
            .Skip(pagedResultInfo.ItemsToSkip())
            .Take(request.PageSize)
            .ToArrayAsync(cancellationToken);

        return new PagedResult<GetAllPostsQueryResult>(pagedResultInfo, result);
    }

    public async Task<GetPostQueryResult> GetPostQueryResultAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Set<PostDatabaseModel>().AsNoTracking()
            .Where(x => x.Id == id)
            .Select(x => new GetPostQueryResult()
            {
                Id = x.Id,
                AuthorId = x.Author.Id,
                AuthorName = x.Author.DisplayName,
                Avaliations = x.Avaliations.Count,
                AverageRate = x.AverageRate,
                Comments = x.Comments.Count,
                Content = x.Content,
                DateOfCreation = x.DateOfCreation,
                DateOfModification = x.DateOfModification,
                Shares = x.Shareds.Count,
                SubTitle = x.SubTitle,
                Title = x.Title
            }).FirstOrDefaultAsync(cancellationToken);
    }
}
