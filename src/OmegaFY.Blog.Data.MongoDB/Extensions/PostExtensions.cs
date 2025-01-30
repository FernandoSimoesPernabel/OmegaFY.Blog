using OmegaFY.Blog.Data.MongoDB.Models;
using OmegaFY.Blog.Domain.Entities.Posts;

namespace OmegaFY.Blog.Data.MongoDB.Extensions;

public static class PostExtensions
{
    public static PostCollectionModel ToPostCollectionModel(this Post post)
    {
        return new PostCollectionModel()
        {
            Id = post.Id,
            AuthorId = post.AuthorId,
            Body = post.Body,
            DateOfCreation = post.ModificationDetails.DateOfCreation,
            DateOfModification = post.ModificationDetails.DateOfModification,
            Private = post.Private,
            SubTitle = post.Header.SubTitle,
            Title = post.Header.Title
        };
    }
}