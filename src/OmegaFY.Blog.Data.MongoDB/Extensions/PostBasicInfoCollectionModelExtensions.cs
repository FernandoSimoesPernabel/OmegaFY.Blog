using OmegaFY.Blog.Data.MongoDB.Models;
using OmegaFY.Blog.Domain.Entities.Posts;

namespace OmegaFY.Blog.Data.MongoDB.Extensions;

public static class PostBasicInfoCollectionModelExtensions
{
    public static Post ToPost(this PostBasicInfoCollectionModel postModel) 
        => Post.Create(postModel.Id, postModel.AuthorId, postModel.Header, postModel.Body, postModel.ModificationDetails, postModel.Private);
}