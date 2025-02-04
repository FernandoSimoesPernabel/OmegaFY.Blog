using MongoDB.Driver;
using OmegaFY.Blog.Application.Queries.Avaliations.GetAvaliationsFromPost;
using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.QueryProviders.Shares;
using OmegaFY.Blog.Application.Queries.Shares.CurrentUserHasSharedPost;
using OmegaFY.Blog.Application.Queries.Shares.GetMostRecentShares;
using OmegaFY.Blog.Data.MongoDB.Constants;
using OmegaFY.Blog.Data.MongoDB.Models;

namespace OmegaFY.Blog.Data.MongoDB.QueryProviders;

internal class ShareQueryProvider : IShareQueryProvider
{
    private readonly IMongoCollection<PostCollectionModel> _postCollection;

    private readonly IMongoCollection<UserCollectionModel> _userCollection;

    public ShareQueryProvider(IMongoDatabase database)
    {
        _postCollection = database.GetCollection<PostCollectionModel>(MongoDbContants.POST_COLLECTION);
        _userCollection = database.GetCollection<UserCollectionModel>(MongoDbContants.USER_COLLECTION);
    }

    public async Task<CurrentUserHasSharedPostQueryResult> CurrentUserHasSharedPostQueryResultAsync(Guid postId, Guid authorId, CancellationToken cancellationToken)
    {
        FilterDefinition<PostCollectionModel> filter = Builders<PostCollectionModel>.Filter.Where(post => post.Id == postId);

        ProjectionDefinition<PostCollectionModel, SharedCollectionModel> projection =
            Builders<PostCollectionModel>.Projection.Expression(post => post.Shareds.Where(shared => shared.AuthorId == authorId).FirstOrDefault());

        SharedCollectionModel shareFromUser = await _postCollection.Find(filter).Project(projection).FirstOrDefaultAsync(cancellationToken);

        return new CurrentUserHasSharedPostQueryResult(postId, shareFromUser?.Id);
    }

    public Task<PagedResult<GetMostRecentSharesQueryResult>> GetMostRecentSharesQueryResultAsync(GetMostRecentSharesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}