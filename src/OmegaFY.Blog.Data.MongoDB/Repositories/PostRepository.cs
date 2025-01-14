using MongoDB.Driver;
using OmegaFY.Blog.Data.MongoDB.Constants;
using OmegaFY.Blog.Data.MongoDB.Repositories.Base;
using OmegaFY.Blog.Domain.Entities.Posts;
using OmegaFY.Blog.Domain.Repositories.Posts;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Data.MongoDB.Repositories;

internal sealed class PostRepository : BaseRepository<Post>, IPostRepository
{
    protected override string CollectionName => MongoDbContants.POST_COLLECTION;

    public PostRepository(IMongoDatabase database) : base(database) { }

    public Task AddPostAsync(Post post, CancellationToken cancellationToken)
        => _collection.InsertOneAsync(post, null, cancellationToken);

    public Task UpdatePostAsync(Post post, CancellationToken cancellationToken)
    {
        UpdateDefinition<Post> update = Builders<Post>.Update
            .Set(p => p.Header, post.Header)
            .Set(p => p.Body, post.Body)
            .Set(p => p.ModificationDetails, post.ModificationDetails)
            .Set(p => p.Private, post.Private);

        return _collection.UpdateOneAsync(p => p.Id == post.Id && p.AuthorId == post.AuthorId, update, null, cancellationToken);
    }

    public Task<Post> GetByIdAsync(ReferenceId postId, ReferenceId authorId, CancellationToken cancellationToken)
        => _collection.Find(post => post.Id == postId && post.AuthorId == authorId).FirstOrDefaultAsync(cancellationToken);
}
