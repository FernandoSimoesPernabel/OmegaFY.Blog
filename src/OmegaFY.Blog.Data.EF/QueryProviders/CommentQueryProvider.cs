using Microsoft.EntityFrameworkCore;
using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.Comments.GetComment;
using OmegaFY.Blog.Application.Queries.Comments.GetCommentsFromPostsFromPost;
using OmegaFY.Blog.Application.Queries.Comments.GetMostReactedComments;
using OmegaFY.Blog.Application.Queries.Comments.GetMostRecentComments;
using OmegaFY.Blog.Application.Queries.Comments.GetReactionsFromPost;
using OmegaFY.Blog.Application.Queries.QueryProviders.Comments;
using OmegaFY.Blog.Data.EF.Context;
using OmegaFY.Blog.Data.EF.Models;

namespace OmegaFY.Blog.Data.EF.QueryProviders;

internal class CommentQueryProvider : ICommentQueryProvider
{
    private readonly QueryContext _context;

    public CommentQueryProvider(QueryContext context) => _context = context;

    public async Task<GetCommentQueryResult> GetCommentQueryResultAsync(GetCommentQuery request, CancellationToken cancellationToken)
    {
        return await _context.Set<CommentDatabaseModel>()
            .Where(comment => comment.Id == request.CommentId)
            .Select(comment => new GetCommentQueryResult()
            {
                CommentAuthorId = comment.AuthorId,
                CommentAuthorName = comment.Author.DisplayName,
                CommentId = comment.Id,
                Content = comment.Content,
                DateOfCreation = comment.DateOfCreation,
                DateOfModification = comment.DateOfModification,
                PostId = comment.PostId,
                Reactions = comment.Reactions.Count
            })
            .OrderByDescending(comment => comment.DateOfCreation)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<GetCommentsFromPostQueryResult> GetCommentsFromPostQueryResultAsync(GetCommentsFromPostQuery request, CancellationToken cancellationToken)
    {
        CommentFromPost[] result = await _context.Set<CommentDatabaseModel>()
            .Where(comment => comment.Id == request.PostId)
            .Select(comment => new CommentFromPost()
            {
                CommentAuthorId = comment.AuthorId,
                CommentAuthorName = comment.Author.DisplayName,
                CommentId = comment.Id,
                Content = comment.Content,
                DateOfCreation = comment.DateOfCreation,
                HasCommentBeenEdit = comment.DateOfModification.HasValue,
                PostId = comment.PostId,
                Reactions = comment.Reactions.Count
            })
            .OrderByDescending(comment => comment.DateOfCreation)
            .ToArrayAsync(cancellationToken);

        return new GetCommentsFromPostQueryResult(result);
    }

    public async Task<PagedResult<GetMostReactedCommentsQueryResult>> GetMostReactedCommentsQueryResultAsync(GetMostReactedCommentsQuery request, CancellationToken cancellationToken)
    {
        IQueryable<CommentDatabaseModel> query = _context.Set<CommentDatabaseModel>()
            .OrderByDescending(comment => comment.Reactions)
            .Where(comment => !comment.Post.Private);

        if (request.AuthorId.HasValue)
            query = query.Where(comment => comment.AuthorId == request.AuthorId.Value);

        int totalOfItens = await query.CountAsync(cancellationToken);

        PagedResultInfo pagedResultInfo = new PagedResultInfo(request.PageNumber, request.PageSize, totalOfItens);

        GetMostReactedCommentsQueryResult[] result =
            await query.Select(comment => new GetMostReactedCommentsQueryResult()
            {
                CommentAuthorId = comment.AuthorId,
                CommentAuthorName = comment.Author.DisplayName,
                CommentId = comment.Id,
                Content = comment.Content,
                DateOfCreation = comment.DateOfCreation,
                HasCommentBeenEdit = comment.DateOfModification.HasValue,
                PostId = comment.PostId,
                Reactions = comment.Reactions.Count
            })
            .Skip(pagedResultInfo.ItemsToSkip())
            .Take(request.PageSize)
            .ToArrayAsync(cancellationToken);

        return new PagedResult<GetMostReactedCommentsQueryResult>(pagedResultInfo, result);
    }

    public async Task<PagedResult<GetMostRecentCommentsQueryResult>> GetMostRecentCommentsQueryResultAsync(GetMostRecentCommentsQuery request, CancellationToken cancellationToken)
    {
        IQueryable<CommentDatabaseModel> query = _context.Set<CommentDatabaseModel>()
            .OrderByDescending(comment => comment.DateOfCreation)
            .Where(comment => !comment.Post.Private);

        if (request.AuthorId.HasValue)
            query = query.Where(comment => comment.AuthorId == request.AuthorId.Value);

        int totalOfItens = await query.CountAsync(cancellationToken);

        PagedResultInfo pagedResultInfo = new PagedResultInfo(request.PageNumber, request.PageSize, totalOfItens);

        GetMostRecentCommentsQueryResult[] result =
            await query.Select(comment => new GetMostRecentCommentsQueryResult()
            {
                CommentAuthorId = comment.AuthorId,
                CommentAuthorName = comment.Author.DisplayName,
                CommentId = comment.Id,
                Content = comment.Content,
                DateOfCreation = comment.DateOfCreation,
                HasCommentBeenEdit = comment.DateOfModification.HasValue,
                PostId = comment.PostId,
                Reactions = comment.Reactions.Count
            })
            .Skip(pagedResultInfo.ItemsToSkip())
            .Take(request.PageSize)
            .ToArrayAsync(cancellationToken);

        return new PagedResult<GetMostRecentCommentsQueryResult>(pagedResultInfo, result);
    }

    public async Task<GetReactionsFromCommentQueryResult> GetReactionsFromCommentQueryResultAsync(GetReactionsFromCommentQuery request, CancellationToken cancellationToken)
    {
        ReactionFromPost[] result = await _context.Set<ReactionDatabaseModel>()
            .Where(reaction => reaction.CommentId == request.CommentId)
            .Select(reaction => new ReactionFromPost()
            {
                CommentId = reaction.CommentId,
                CommentReaction = reaction.CommentReaction,
                ReactionAuthorId = reaction.AuthorId,
                ReactionAuthorName = reaction.Author.DisplayName,
                ReactionId = reaction.Id
            })
            .ToArrayAsync(cancellationToken);

        return new GetReactionsFromCommentQueryResult(result);
    }
}