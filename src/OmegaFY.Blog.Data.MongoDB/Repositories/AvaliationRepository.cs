using MongoDB.Driver;
using OmegaFY.Blog.Data.MongoDB.Constants;
using OmegaFY.Blog.Data.MongoDB.Extensions;
using OmegaFY.Blog.Data.MongoDB.Models;
using OmegaFY.Blog.Data.MongoDB.Repositories.Base;
using OmegaFY.Blog.Domain.Entities.Avaliations;
using OmegaFY.Blog.Domain.Repositories.Avaliations;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Data.MongoDB.Repositories;

internal class AvaliationRepository : BaseRepository<PostAvaliations, PostAvaliationsCollectionModel>, IAvaliationRepository
{
    protected override string CollectionName => MongoDbContants.POST_COLLECTION;

    public AvaliationRepository(IMongoDatabase database) : base(database) { }

    public async Task<PostAvaliations> GetPostByIdAsync(ReferenceId postId, CancellationToken cancellationToken)
    {
        PostAvaliationsCollectionModel postModel = await _collection.Find(post => post.Id == postId).FirstOrDefaultAsync(cancellationToken);
        return postModel?.ToPostAvaliations();
    }

    public Task UpdatePostAvaliationsAsync(PostAvaliations postAvaliations, CancellationToken cancellationToken)
    {
        FilterDefinition<PostAvaliationsCollectionModel> filter = Builders<PostAvaliationsCollectionModel>.Filter.Eq(post => post.Id, postAvaliations.Id);

        UpdateDefinition<PostAvaliationsCollectionModel> update = Builders<PostAvaliationsCollectionModel>.Update
            .Set(nameof(PostAvaliationsCollectionModel.Avaliations), postAvaliations.Avaliations)
            .Set(nameof(PostAvaliationsCollectionModel.AverageRate), postAvaliations.AverageRate);

        return _collection.UpdateOneAsync(filter, update, null, cancellationToken);
    }
}