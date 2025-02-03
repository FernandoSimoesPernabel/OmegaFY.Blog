using MongoDB.Driver;
using OmegaFY.Blog.Application.Queries.Avaliations.GetAvaliationsFromPost;
using OmegaFY.Blog.Application.Queries.Avaliations.GetMostRecentAvaliations;
using OmegaFY.Blog.Application.Queries.Avaliations.GetTopRatedPosts;
using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.Posts.GetMostRecentPublishedPosts;
using OmegaFY.Blog.Application.Queries.QueryProviders.Avaliations;
using OmegaFY.Blog.Data.MongoDB.Constants;
using OmegaFY.Blog.Data.MongoDB.Extensions;
using OmegaFY.Blog.Data.MongoDB.Models;
using OmegaFY.Blog.Domain.Entities.Avaliations;
using SendGrid.Helpers.Mail;

namespace OmegaFY.Blog.Data.MongoDB.QueryProviders;

internal class AvaliationQueryProvider : IAvaliationQueryProvider
{
    private readonly IMongoCollection<PostCollectionModel> _postCollection;

    private readonly IMongoCollection<UserCollectionModel> _userCollection;

    public AvaliationQueryProvider(IMongoDatabase database)
    {
        _postCollection = database.GetCollection<PostCollectionModel>(MongoDbContants.POST_COLLECTION);
        _userCollection = database.GetCollection<UserCollectionModel>(MongoDbContants.USER_COLLECTION);
    }

    public async Task<GetAvaliationsFromPostQueryResult> GetAvaliationsFromPostQueryResultAsync(
        GetAvaliationsFromPostQuery request,
        CancellationToken cancellationToken)
    {
        FilterDefinition<PostCollectionModel> filter = Builders<PostCollectionModel>.Filter.Where(post => post.Id == request.PostId && !post.Private);

        ProjectionDefinition<PostCollectionModel, AvaliationFromPost[]> projection =
            Builders<PostCollectionModel>.Projection.Expression(post => post.Avaliations.Select(avaliation => new AvaliationFromPost()
            {
                AvaliationId = avaliation.Id,
                AuthorId = avaliation.AuthorId,
                AvaliationDate = avaliation.DateOfModification ?? avaliation.DateOfCreation,
                HasAvaliationBeenEdit = avaliation.DateOfModification.HasValue,
                PostId = post.Id,
                PostTitle = post.Title,
                Rate = avaliation.Rate
            }).OrderByDescending(avaliation => avaliation.AvaliationDate).ToArray());

        AvaliationFromPost[] result = await _postCollection.Find(filter).Project(projection).FirstOrDefaultAsync(cancellationToken);

        await _userCollection.HydrateAuthorNamesAsync(
            result,
            result => result.Select(query => query.AuthorId).ToArray(),
            (result, users) => Array.ForEach(result, query =>
            {
                UserCollectionModel postAuthor = users.First(user => user.Id == query.AuthorId);
                query.AuthorName = postAuthor.DisplayName;
            }),
            cancellationToken);

        return new GetAvaliationsFromPostQueryResult(result);
    }

    public async Task<PagedResult<GetMostRecentAvaliationsQueryResult>> GetMostRecentAvaliationsQueryResultAsync(
        GetMostRecentAvaliationsQuery request,
        CancellationToken cancellationToken)
    {
        FilterDefinition<PostCollectionModel> filter = Builders<PostCollectionModel>.Filter.Where(post => !post.Private);

        int totalOfItems = (int)await _postCollection.CountDocumentsAsync(filter, cancellationToken: cancellationToken);

        ProjectionDefinition<PostCollectionModel, GetMostRecentAvaliationsQueryResult[]> projection =
            Builders<PostCollectionModel>.Projection.Expression(post => post.Avaliations.Select(avaliation => new GetMostRecentAvaliationsQueryResult()
            {
                AvaliationId = avaliation.Id,
                AuthorId = avaliation.AuthorId,
                AvaliationDate = avaliation.DateOfModification ?? avaliation.DateOfCreation,
                HasAvaliationBeenEdit = avaliation.DateOfModification.HasValue,
                PostId = post.Id,
                PostTitle = post.Title,
                Rate = avaliation.Rate
            }).OrderByDescending(avaliation => avaliation.AvaliationDate).ToArray());

        PagedResultInfo pagedResultInfo = new PagedResultInfo(request.PageNumber, request.PageSize, totalOfItems);

        GetMostRecentAvaliationsQueryResult[][] allAvaliations = await _postCollection.Find(filter)
            .Skip(pagedResultInfo.ItemsToSkip())
            .Limit(pagedResultInfo.PageSize)
            .Project(projection)
            .ToArrayAsync(cancellationToken);

        GetMostRecentAvaliationsQueryResult[] result = allAvaliations.SelectMany(avaliation => avaliation).ToArray();

        await _userCollection.HydrateAuthorNamesAsync(
            result,
            result => result.Select(query => query.AuthorId).ToArray(),
            (result, users) => Array.ForEach(result, query =>
            {
                UserCollectionModel postAuthor = users.First(user => user.Id == query.AuthorId);
                query.AuthorName = postAuthor.DisplayName;
            }),
            cancellationToken);

        return new PagedResult<GetMostRecentAvaliationsQueryResult>(pagedResultInfo, result);
    }


    public async Task<PagedResult<GetTopRatedPostsQueryResult>> GetTopRatedPostsQueryResultAsync(GetTopRatedPostsQuery request, CancellationToken cancellationToken)
    {
        FilterDefinition<PostCollectionModel> filter = Builders<PostCollectionModel>.Filter.Where(post => !post.Private);

        int totalOfItems = (int)await _postCollection.CountDocumentsAsync(filter, cancellationToken: cancellationToken);

        PagedResultInfo pagedResultInfo = new PagedResultInfo(request.PageNumber, request.PageSize, totalOfItems);

        GetTopRatedPostsQueryResult[] result = await _postCollection.Find(filter)
            .SortByDescending(post => post.DateOfCreation)
            .Skip(pagedResultInfo.ItemsToSkip())
            .Limit(pagedResultInfo.PageSize)
            .Project(post => new GetTopRatedPostsQueryResult()
            {
                PostId = post.Id,
                AuthorId = post.AuthorId,
                AverageRate = post.AverageRate,
                DateOfCreation = post.DateOfCreation,
                PostTitle = post.Title                
            }).ToArrayAsync(cancellationToken);

        await _userCollection.HydrateAuthorNamesAsync(
            result,
            result => result.Select(query => query.AuthorId).ToArray(),
            (result, users) => Array.ForEach(result, query =>
            {
                UserCollectionModel postAuthor = users.First(user => user.Id == query.AuthorId);
                query.PostAuthorName = postAuthor.DisplayName;
            }),
            cancellationToken);

        return new PagedResult<GetTopRatedPostsQueryResult>(pagedResultInfo, result);
    }
}