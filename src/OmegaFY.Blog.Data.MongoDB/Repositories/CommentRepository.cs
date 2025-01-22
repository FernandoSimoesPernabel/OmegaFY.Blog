using MongoDB.Driver;
using OmegaFY.Blog.Data.MongoDB.Models;
using OmegaFY.Blog.Data.MongoDB.Repositories.Base;
using OmegaFY.Blog.Domain.Entities.Comments;
using OmegaFY.Blog.Domain.Repositories.Comments;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Data.MongoDB.Repositories;

internal sealed class CommentRepository : BaseRepository<PostComments, PostCommentsCollectionModel>, ICommentRepository
{
    protected override string CollectionName => throw new NotImplementedException();

    public CommentRepository(IMongoDatabase database) : base(database) { }

    public Task<PostComments> GetPostByIdAsync(ReferenceId postId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}