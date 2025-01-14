using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using OmegaFY.Blog.Data.MongoDB.Constants;
using OmegaFY.Blog.Data.MongoDB.Repositories.Base;
using OmegaFY.Blog.Domain.Entities.Avaliations;
using OmegaFY.Blog.Domain.Entities.Posts;
using OmegaFY.Blog.Domain.Repositories.Avaliations;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Data.MongoDB.Repositories;

internal class AvaliationRepository : BaseRepository<PostAvaliations>, IAvaliationRepository
{
    protected override string CollectionName => MongoDbContants.POST_COLLECTION;

    public AvaliationRepository(IMongoDatabase database) : base(database) { }

    public Task<PostAvaliations> GetPostByIdAsync(ReferenceId postId, CancellationToken cancellationToken) 
        => _collection.Find(post => post.Id == postId).FirstOrDefaultAsync(cancellationToken);

    public async Task UpdatePostAvaliationsAsync(PostAvaliations postAvaliations, CancellationToken cancellationToken)
    {
        FilterDefinition<PostAvaliations> filter = Builders<PostAvaliations>.Filter.Eq(post => post.Id, postAvaliations.Id);

        UpdateDefinition<PostAvaliations> update = Builders<PostAvaliations>.Update
            .Set("Avaliations", postAvaliations.Avaliations)
            .Set("AverageRate", postAvaliations.AverageRate);

        await _collection.UpdateOneAsync(filter, update, null, cancellationToken);
    }
}