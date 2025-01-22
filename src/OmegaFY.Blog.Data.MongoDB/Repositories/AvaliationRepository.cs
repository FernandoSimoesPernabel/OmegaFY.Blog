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
        PostAvaliationsCollectionModel postModel = await _collection.Find(post => post.Id == postId.ToObjectId()).FirstOrDefaultAsync(cancellationToken);
        return postModel?.ToPostAvaliations();
    }

    public async Task UpdatePostAvaliationsAsync(PostAvaliations postAvaliations, CancellationToken cancellationToken)
    {
        FilterDefinition<PostAvaliationsCollectionModel> filter = Builders<PostAvaliationsCollectionModel>.Filter.Eq(post => post.Id, postAvaliations.Id.ToObjectId());

        UpdateDefinition<PostAvaliationsCollectionModel> update = Builders<PostAvaliationsCollectionModel>.Update
            .Set("Avaliations", postAvaliations.Avaliations)
            .Set("AverageRate", postAvaliations.AverageRate);

        await _collection.UpdateOneAsync(filter, update, null, cancellationToken);
    }
}