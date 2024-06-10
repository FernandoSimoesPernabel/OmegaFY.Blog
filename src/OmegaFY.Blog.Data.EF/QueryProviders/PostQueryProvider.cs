﻿using Microsoft.EntityFrameworkCore;
using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.Posts.GetAllPosts;
using OmegaFY.Blog.Application.Queries.Posts.GetMostRecentPublishedPosts;
using OmegaFY.Blog.Application.Queries.Posts.GetPost;
using OmegaFY.Blog.Application.Queries.QueryProviders.Posts;
using OmegaFY.Blog.Data.EF.Context;
using OmegaFY.Blog.Data.EF.Extensions;
using OmegaFY.Blog.Data.EF.Models;

namespace OmegaFY.Blog.Data.EF.QueryProviders;

internal class PostQueryProvider : IPostQueryProvider
{
    private readonly QueryContext _context;

    public PostQueryProvider(QueryContext context) => _context = context;

    public async Task<PagedResult<GetAllPostsQueryResult>> GetAllPostsQueryResultAsync(GetAllPostsQuery request, CancellationToken cancellationToken)
    {
        IQueryable<PostDatabaseModel> query = _context.Set<PostDatabaseModel>()
            .Where(post => !post.Private)
            .OrderByDescending(post => post.DateOfCreation);

        if (request.StartDateOfCreation.HasValue && request.EndDateOfCreation.HasValue)
            query = query.Where(post => post.DateOfCreation >= request.StartDateOfCreation.Value && post.DateOfCreation <= request.EndDateOfCreation.Value);

        if (request.AuthorId.HasValue)
            query = query.Where(post => post.Author.Id == request.AuthorId.Value);

        int totalOfItens = await query.CountAsync(cancellationToken);

        PagedResultInfo pagedResultInfo = new PagedResultInfo(request.PageNumber, request.PageSize, totalOfItens);

        GetAllPostsQueryResult[] result =
            await query.Select(post => new GetAllPostsQueryResult()
            {
                PostId = post.Id,
                AverageRate = post.AverageRate,
                AuthorName = post.Author.DisplayName,
                DateOfCreation = post.DateOfCreation,
                HasPostBeenEdit = post.DateOfModification.HasValue,
                Title = post.Title
            })
            .Paginate(pagedResultInfo)
            .ToArrayAsync(cancellationToken);

        return new PagedResult<GetAllPostsQueryResult>(pagedResultInfo, result);
    }

    public async Task<PagedResult<GetMostRecentPublishedPostsQueryResult>> GetMostRecentPublishedPostsQueryResultAsync(
        GetMostRecentPublishedPostsQuery request,
        CancellationToken cancellationToken)
    {
        IQueryable<PostDatabaseModel> query = _context.Set<PostDatabaseModel>()
            .Where(post => !post.Private)
            .OrderByDescending(post => post.DateOfCreation);

        if (request.AuthorId.HasValue)
            query = query.Where(post => post.Author.Id == request.AuthorId.Value);

        int totalOfItens = await query.CountAsync(cancellationToken);

        PagedResultInfo pagedResultInfo = new PagedResultInfo(request.PageNumber, request.PageSize, totalOfItens);

        GetMostRecentPublishedPostsQueryResult[] result =
            await query.Select(x => new GetMostRecentPublishedPostsQueryResult()
            {
                PostId = x.Id,
                AuthorName = x.Author.DisplayName,
                DateOfCreation = x.DateOfCreation,
                Title = x.Title
            })
            .Paginate(pagedResultInfo)
            .ToArrayAsync(cancellationToken);

        return new PagedResult<GetMostRecentPublishedPostsQueryResult>(pagedResultInfo, result);
    }

    public async Task<GetPostQueryResult> GetPostQueryResultAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Set<PostDatabaseModel>()
            .Where(post => post.Id == id)
            .Select(post => new GetPostQueryResult()
            {
                PostId = post.Id,
                AuthorId = post.Author.Id,
                AuthorName = post.Author.DisplayName,
                Avaliations = post.Avaliations.Count,
                AverageRate = post.AverageRate,
                Comments = post.Comments.Count,
                Content = post.Content,
                DateOfCreation = post.DateOfCreation,
                DateOfModification = post.DateOfModification,
                Private = post.Private,
                Shares = post.Shareds.Count,
                SubTitle = post.SubTitle,
                Title = post.Title
            }).FirstOrDefaultAsync(cancellationToken);
    }
}