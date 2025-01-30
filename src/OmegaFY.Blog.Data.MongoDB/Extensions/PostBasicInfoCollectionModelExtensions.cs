using OmegaFY.Blog.Data.MongoDB.Models;
using OmegaFY.Blog.Domain.Entities.Posts;
using OmegaFY.Blog.Domain.ValueObjects.Posts;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Data.MongoDB.Extensions;

public static class PostCollectionModelExtensions
{
    public static Post ToPost(this PostCollectionModel postModel)
    {
        return Post.Create(
            postModel.Id, 
            postModel.AuthorId,
            new Header(postModel.Title, postModel.SubTitle), 
            postModel.Body, 
            new ModificationDetails(postModel.DateOfCreation, postModel.DateOfModification), 
            postModel.Private);
    }
}