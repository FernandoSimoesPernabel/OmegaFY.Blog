using MongoDB.Driver;
using OmegaFY.Blog.Data.MongoDB.Constants;
using OmegaFY.Blog.Data.MongoDB.Extensions;
using OmegaFY.Blog.Data.MongoDB.Models;
using OmegaFY.Blog.Data.MongoDB.Repositories.Base;
using OmegaFY.Blog.Domain.Entities.Posts;
using OmegaFY.Blog.Domain.Repositories.Posts;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Data.MongoDB.Repositories;

internal sealed class PostRepository : BaseRepository<Post, PostCollectionModel>, IPostRepository
{
    protected override string CollectionName => MongoDbContants.POST_COLLECTION;

    public PostRepository(IMongoDatabase database) : base(database) { }

    public Task AddPostAsync(Post post, CancellationToken cancellationToken)
        => _collection.InsertOneAsync(post.ToPostCollectionModel(), null, cancellationToken);

    public Task UpdatePostAsync(Post post, CancellationToken cancellationToken)
    {
        UpdateDefinition<PostCollectionModel> update = Builders<PostCollectionModel>.Update
            .Set(p => p.Header, post.Header)
            .Set(p => p.Body, post.Body)
            .Set(p => p.ModificationDetails, post.ModificationDetails)
            .Set(p => p.Private, post.Private);

        return _collection.UpdateOneAsync(p => p.Id == post.Id.ToObjectId() && p.AuthorId == post.AuthorId.ToObjectId(), update, null, cancellationToken);
    }

    public async Task<Post> GetByIdAsync(ReferenceId postId, ReferenceId authorId, CancellationToken cancellationToken)
    {
        PostCollectionModel postModel = await _collection.Find(post => post.Id == postId.ToObjectId() && post.AuthorId == authorId.ToObjectId()).FirstOrDefaultAsync(cancellationToken);
        return postModel?.ToPost();
    }
}
