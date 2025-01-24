﻿using MongoDB.Driver;
using OmegaFY.Blog.Data.MongoDB.Extensions;
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

    public async Task<PostComments> GetPostByIdAsync(ReferenceId postId, CancellationToken cancellationToken)
    {
        PostCommentsCollectionModel postModel = await _collection.Find(post => post.Id == postId).FirstOrDefaultAsync(cancellationToken);
        return postModel?.ToPostComments();
    }

    public Task UpdatePostCommentsAsync(PostComments postComments, CancellationToken cancellationToken)
    {
        FilterDefinition<PostCommentsCollectionModel> filter = Builders<PostCommentsCollectionModel>.Filter.Eq(post => post.Id, postComments.Id);

        UpdateDefinition<PostCommentsCollectionModel> update =
            Builders<PostCommentsCollectionModel>.Update.Set(nameof(PostCommentsCollectionModel.Comments), postComments.Comments);

        return _collection.UpdateOneAsync(filter, update, null, cancellationToken);
    }
}