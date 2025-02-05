using MongoDB.Driver;
using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.Comments.GetComment;
using OmegaFY.Blog.Application.Queries.Comments.GetCommentsFromPost;
using OmegaFY.Blog.Application.Queries.Comments.GetMostReactedComments;
using OmegaFY.Blog.Application.Queries.Comments.GetMostRecentComments;
using OmegaFY.Blog.Application.Queries.Comments.GetReactionsFromComment;
using OmegaFY.Blog.Application.Queries.QueryProviders.Comments;
using OmegaFY.Blog.Data.MongoDB.Constants;
using OmegaFY.Blog.Data.MongoDB.Extensions;
using OmegaFY.Blog.Data.MongoDB.Models;

namespace OmegaFY.Blog.Data.MongoDB.QueryProviders;

internal class CommentQueryProvider : ICommentQueryProvider
{
    private readonly IMongoCollection<PostCollectionModel> _postCollection;

    private readonly IMongoCollection<UserCollectionModel> _userCollection;

    public CommentQueryProvider(IMongoDatabase database)
    {
        _postCollection = database.GetCollection<PostCollectionModel>(MongoDbContants.POST_COLLECTION);
        _userCollection = database.GetCollection<UserCollectionModel>(MongoDbContants.USER_COLLECTION);
    }

    public async Task<GetCommentQueryResult> GetCommentQueryResultAsync(GetCommentQuery request, CancellationToken cancellationToken)
    {
        FilterDefinition<PostCollectionModel> filter = Builders<PostCollectionModel>.Filter.ElemMatch(post => post.Comments, comment => comment.Id == request.CommentId);

        ProjectionDefinition<PostCollectionModel, GetCommentQueryResult> projection =
            Builders<PostCollectionModel>.Projection.Expression(post => post.Comments.Where(comment => comment.Id == request.CommentId)
                .Select(comment => new GetCommentQueryResult()
                {
                    CommentId = comment.Id,
                    CommentAuthorId = comment.AuthorId,
                    PostId = comment.PostId,
                    Content = comment.Body,
                    DateOfCreation = comment.DateOfCreation,
                    DateOfModification = comment.DateOfModification,
                    Reactions = comment.Reactions.Length
                }).FirstOrDefault());

        GetCommentQueryResult result = await _postCollection.Find(filter).Project(projection).FirstOrDefaultAsync(cancellationToken);

        await _userCollection.HydrateAuthorNameAsync(
            result,
            result.CommentAuthorId,
            (result, user) => result.CommentAuthorName = user.DisplayName,
            cancellationToken);

        return result;
    }

    public async Task<GetCommentsFromPostQueryResult> GetCommentsFromPostQueryResultAsync(GetCommentsFromPostQuery request, CancellationToken cancellationToken)
    {
        FilterDefinition<PostCollectionModel> filter = Builders<PostCollectionModel>.Filter.Where(post => post.Id == request.PostId);

        ProjectionDefinition<PostCollectionModel, CommentFromPost[]> projection =
            Builders<PostCollectionModel>.Projection.Expression(post => post.Comments.Select(comment => new CommentFromPost()
            {
                CommentId = comment.Id,
                CommentAuthorId = comment.AuthorId,
                PostId = comment.PostId,
                Content = comment.Body,
                DateOfCreation = comment.DateOfCreation,
                HasCommentBeenEdit = comment.DateOfModification.HasValue,
                ReactionCount = comment.Reactions.Length
            }).OrderByDescending(comment => comment.DateOfCreation).ToArray());

        CommentFromPost[] result = await _postCollection.Find(filter).Project(projection).FirstOrDefaultAsync(cancellationToken);

        await _userCollection.HydrateAuthorNamesAsync(
            result,
            result => result.Select(comment => comment.CommentAuthorId).ToArray(),
            (result, users) => Array.ForEach(result, comment =>
            {
                UserCollectionModel commentAuthor = users.First(user => user.Id == comment.CommentAuthorId);
                comment.CommentAuthorName = commentAuthor.DisplayName;
            }),
            cancellationToken);

        return new GetCommentsFromPostQueryResult(result);
    }

    public async Task<PagedResult<GetMostReactedCommentsQueryResult>> GetMostReactedCommentsQueryResultAsync(GetMostReactedCommentsQuery request, CancellationToken cancellationToken)
    {
        FilterDefinition<PostCollectionModel> filter = Builders<PostCollectionModel>.Filter.Where(post => !post.Private);

        ProjectionDefinition<PostCollectionModel, GetMostReactedCommentsQueryResult[]> projection =
            Builders<PostCollectionModel>.Projection.Expression(post => post.Comments.Select(comment => new GetMostReactedCommentsQueryResult()
            {
                CommentId = comment.Id,
                CommentAuthorId = comment.AuthorId,
                PostId = comment.PostId,
                Content = comment.Body,
                DateOfCreation = comment.DateOfCreation,
                HasCommentBeenEdit = comment.DateOfModification.HasValue,
                ReactionCount = comment.Reactions.Length
            }).OrderByDescending(comment => comment.ReactionCount).ToArray());

        long totalOfItems = await _postCollection.AggregateCountAsync(filter, post => post.Comments, cancellationToken);

        PagedResultInfo pagedResultInfo = new PagedResultInfo(request.PageNumber, request.PageSize, totalOfItems);

        GetMostReactedCommentsQueryResult[] result = await _postCollection.Find(filter).Paginate(pagedResultInfo).Project(projection).FirstOrDefaultAsync(cancellationToken);

        await _userCollection.HydrateAuthorNamesAsync(
            result,
            result => result.Select(comment => comment.CommentAuthorId).ToArray(),
            (result, users) => Array.ForEach(result, comment =>
            {
                UserCollectionModel commentAuthor = users.First(user => user.Id == comment.CommentAuthorId);
                comment.CommentAuthorName = commentAuthor.DisplayName;
            }),
            cancellationToken);

        return new PagedResult<GetMostReactedCommentsQueryResult>(pagedResultInfo, result);
    }

    public async Task<PagedResult<GetMostRecentCommentsQueryResult>> GetMostRecentCommentsQueryResultAsync(GetMostRecentCommentsQuery request, CancellationToken cancellationToken)
    {
        FilterDefinition<PostCollectionModel> filter = Builders<PostCollectionModel>.Filter.Where(post => !post.Private);

        ProjectionDefinition<PostCollectionModel, GetMostRecentCommentsQueryResult[]> projection =
            Builders<PostCollectionModel>.Projection.Expression(post => post.Comments.Select(comment => new GetMostRecentCommentsQueryResult()
            {
                CommentId = comment.Id,
                CommentAuthorId = comment.AuthorId,
                PostId = comment.PostId,
                Content = comment.Body,
                DateOfCreation = comment.DateOfCreation,
                HasCommentBeenEdit = comment.DateOfModification.HasValue,
                ReactionCount = comment.Reactions.Length
            }).OrderByDescending(comment => comment.ReactionCount).ToArray());

        long totalOfItems = await _postCollection.AggregateCountAsync(filter, post => post.Comments, cancellationToken);

        PagedResultInfo pagedResultInfo = new PagedResultInfo(request.PageNumber, request.PageSize, totalOfItems);

        GetMostRecentCommentsQueryResult[] result = await _postCollection.Find(filter).Project(projection).FirstOrDefaultAsync(cancellationToken);

        await _userCollection.HydrateAuthorNamesAsync(
            result,
            result => result.Select(comment => comment.CommentAuthorId).ToArray(),
            (result, users) => Array.ForEach(result, comment =>
            {
                UserCollectionModel commentAuthor = users.First(user => user.Id == comment.CommentAuthorId);
                comment.CommentAuthorName = commentAuthor.DisplayName;
            }),
            cancellationToken);

        return new PagedResult<GetMostRecentCommentsQueryResult>(pagedResultInfo, result);
    }

    public async Task<GetReactionsFromCommentQueryResult> GetReactionsFromCommentQueryResultAsync(GetReactionsFromCommentQuery request, CancellationToken cancellationToken)
    {
        FilterDefinition<PostCollectionModel> filter = Builders<PostCollectionModel>.Filter.ElemMatch(post => post.Comments, comment => comment.Id == request.CommentId);

        ProjectionDefinition<PostCollectionModel, ReactionFromComment[]> projection =
            Builders<PostCollectionModel>.Projection.Expression(post => post.Comments.Where(comment => comment.Id == request.CommentId)
                .SelectMany(comment => comment.Reactions)
                .Select(reaction => new ReactionFromComment()
                {
                    ReactionId = reaction.Id,
                    CommentId = reaction.CommentId,
                    ReactionAuthorId = reaction.AuthorId,
                    CommentReaction = reaction.CommentReaction
                }).ToArray());

        ReactionFromComment[] result = await _postCollection.Find(filter).Project(projection).FirstOrDefaultAsync(cancellationToken);

        await _userCollection.HydrateAuthorNamesAsync(
            result,
            result => result.Select(comment => comment.ReactionAuthorId).ToArray(),
            (result, users) => Array.ForEach(result, comment =>
            {
                UserCollectionModel commentAuthor = users.First(user => user.Id == comment.ReactionAuthorId);
                comment.ReactionAuthorName = commentAuthor.DisplayName;
            }),
            cancellationToken);

        return new GetReactionsFromCommentQueryResult(result);
    }
}