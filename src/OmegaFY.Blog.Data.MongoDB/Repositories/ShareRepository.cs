using MongoDB.Driver;
using OmegaFY.Blog.Data.MongoDB.Extensions;
using OmegaFY.Blog.Data.MongoDB.Models;
using OmegaFY.Blog.Data.MongoDB.Repositories.Base;
using OmegaFY.Blog.Domain.Entities.Shares;
using OmegaFY.Blog.Domain.Repositories.Shares;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Data.MongoDB.Repositories;

internal sealed class ShareRepository : BaseRepository<PostShares, PostSharesCollectionModel>, IShareRepository
{
    protected override string CollectionName => throw new NotImplementedException();

    public ShareRepository(IMongoDatabase database) : base(database) { }

    public async Task<PostShares> GetPostByIdAsync(ReferenceId postId, CancellationToken cancellationToken)
    {
        PostSharesCollectionModel postModel = await _collection.Find(post => post.Id == postId.Value).FirstOrDefaultAsync(cancellationToken);
        return postModel?.ToPostShares();
    }

    public Task UpdatePostShares(PostShares postShares, CancellationToken cancellationToken)
    {
        FilterDefinition<PostSharesCollectionModel> filter = Builders<PostSharesCollectionModel>.Filter.Eq(post => post.Id, postShares.Id.Value);

        UpdateDefinition<PostSharesCollectionModel> update =
            Builders<PostSharesCollectionModel>.Update.Set(nameof(PostSharesCollectionModel.Shareds), postShares.Shareds);

        return _collection.UpdateOneAsync(filter, update, null, cancellationToken);
    }
}