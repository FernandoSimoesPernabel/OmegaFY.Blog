using OmegaFY.Blog.Data.MongoDB.Models;
using OmegaFY.Blog.Domain.Entities.Posts;

namespace OmegaFY.Blog.Data.MongoDB.Extensions;

public static class PostCollectionModelExtensions
{
    public static Post ToPost(this PostCollectionModel postModel) 
        => Post.Create(postModel.Id.ToGuid(), postModel.AuthorId.ToGuid(), postModel.Header, postModel.Body, postModel.ModificationDetails, postModel.Private);
}