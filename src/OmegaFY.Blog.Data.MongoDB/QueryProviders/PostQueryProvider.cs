using MongoDB.Driver;
using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.Posts.GetAllPosts;
using OmegaFY.Blog.Application.Queries.Posts.GetMostRecentPublishedPosts;
using OmegaFY.Blog.Application.Queries.Posts.GetPost;
using OmegaFY.Blog.Application.Queries.QueryProviders.Posts;
using OmegaFY.Blog.Data.MongoDB.Constants;
using OmegaFY.Blog.Data.MongoDB.Extensions;
using OmegaFY.Blog.Data.MongoDB.Models;

namespace OmegaFY.Blog.Data.MongoDB.QueryProviders;

internal class PostQueryProvider : IPostQueryProvider
{
    private readonly IMongoCollection<PostCollectionModel> _postCollection;

    private readonly IMongoCollection<UserCollectionModel> _userCollection;

    public PostQueryProvider(IMongoDatabase database)
    {
        _postCollection = database.GetCollection<PostCollectionModel>(MongoDbContants.POST_COLLECTION);
        _userCollection = database.GetCollection<UserCollectionModel>(MongoDbContants.USER_COLLECTION);
    }

    public async Task<PagedResult<GetAllPostsQueryResult>> GetAllPostsQueryResultAsync(GetAllPostsQuery request, CancellationToken cancellationToken)
    {
        List<FilterDefinition<PostCollectionModel>> filters = new List<FilterDefinition<PostCollectionModel>>
        {
            Builders<PostCollectionModel>.Filter.Eq(post => post.Private, false)
        };

        if (request.StartDateOfCreation.HasValue && request.EndDateOfCreation.HasValue)
        {
            filters.Add(Builders<PostCollectionModel>.Filter.Gte(post => post.DateOfCreation, request.StartDateOfCreation.Value));
            filters.Add(Builders<PostCollectionModel>.Filter.Lte(post => post.DateOfCreation, request.EndDateOfCreation.Value));
        }

        if (request.AuthorId.HasValue)
            filters.Add(Builders<PostCollectionModel>.Filter.Eq(post => post.AuthorId, request.AuthorId.Value));

        FilterDefinition<PostCollectionModel> filter = Builders<PostCollectionModel>.Filter.And(filters);

        int totalOfItems = (int)await _postCollection.CountDocumentsAsync(filter, cancellationToken: cancellationToken);

        PagedResultInfo pagedResultInfo = new PagedResultInfo(request.PageNumber, request.PageSize, totalOfItems);

        GetAllPostsQueryResult[] result = await _postCollection.Find(filter)
            .SortByDescending(post => post.DateOfCreation)
            .Skip(pagedResultInfo.ItemsToSkip())
            .Limit(pagedResultInfo.PageSize)
            .Project(post => new GetAllPostsQueryResult()
            {
                PostId = post.Id,
                AverageRate = post.AverageRate,
                AuthorId = post.AuthorId,
                DateOfCreation = post.DateOfCreation,
                HasPostBeenEdit = post.DateOfModification.HasValue,
                Title = post.Title
            }).ToArrayAsync(cancellationToken);

        await _userCollection.HydrateAuthorNamesAsync(
            result,
            result => result.Select(query => query.AuthorId).ToArray(),
            (result, users) => Array.ForEach(result, query =>
            {
                UserCollectionModel postAuthor = users.First(user => user.Id == query.AuthorId);
                query.AuthorName = postAuthor.DisplayName;
            }),
            cancellationToken);

        return new PagedResult<GetAllPostsQueryResult>(pagedResultInfo, result);
    }

    public async Task<PagedResult<GetMostRecentPublishedPostsQueryResult>> GetMostRecentPublishedPostsQueryResultAsync(GetMostRecentPublishedPostsQuery request, CancellationToken cancellationToken)
    {
        List<FilterDefinition<PostCollectionModel>> filters = new List<FilterDefinition<PostCollectionModel>>
        {
            Builders<PostCollectionModel>.Filter.Eq(post => post.Private, false)
        };

        if (request.AuthorId.HasValue)
            filters.Add(Builders<PostCollectionModel>.Filter.Eq(post => post.AuthorId, request.AuthorId.Value));

        FilterDefinition<PostCollectionModel> filter = Builders<PostCollectionModel>.Filter.And(filters);

        int totalOfItems = (int)await _postCollection.CountDocumentsAsync(filter, cancellationToken: cancellationToken);

        PagedResultInfo pagedResultInfo = new PagedResultInfo(request.PageNumber, request.PageSize, totalOfItems);

        GetMostRecentPublishedPostsQueryResult[] result = await _postCollection.Find(filter)
            .SortByDescending(post => post.DateOfCreation)
            .Skip(pagedResultInfo.ItemsToSkip())
            .Limit(pagedResultInfo.PageSize)
            .Project(post => new GetMostRecentPublishedPostsQueryResult()
            {
                PostId = post.Id,
                AuthorId = post.AuthorId,
                DateOfCreation = post.DateOfCreation,
                Title = post.Title
            }).ToArrayAsync(cancellationToken);

        await _userCollection.HydrateAuthorNamesAsync(
            result,
            result => result.Select(query => query.AuthorId).ToArray(),
            (result, users) => Array.ForEach(result, query =>
            {
                UserCollectionModel postAuthor = users.First(user => user.Id == query.AuthorId);
                query.AuthorName = postAuthor.DisplayName;
            }),
            cancellationToken);

        return new PagedResult<GetMostRecentPublishedPostsQueryResult>(pagedResultInfo, result);
    }

    public async Task<GetPostQueryResult> GetPostQueryResultAsync(Guid id, CancellationToken cancellationToken)
    {
        GetPostQueryResult result = await _postCollection.Find(Builders<PostCollectionModel>.Filter.Eq(post => post.Id, id))
            .Project(post => new GetPostQueryResult()
            {
                PostId = post.Id,
                AuthorId = post.AuthorId,
                Avaliations = post.Avaliations.Count(),
                AverageRate = post.AverageRate,
                Comments = post.Comments.Count(),
                Content = post.Body,
                DateOfCreation = post.DateOfCreation,
                DateOfModification = post.DateOfModification,
                Private = post.Private,
                Shares = post.Shareds.Count(),
                SubTitle = post.SubTitle,
                Title = post.Title
            }).FirstOrDefaultAsync(cancellationToken);

        await _userCollection.HydrateAuthorNameAsync(
            result,
            result.AuthorId,
            (result, user) => result.AuthorName = user.DisplayName,
            cancellationToken);

        return result;
    }
}