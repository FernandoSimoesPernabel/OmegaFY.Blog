using OmegaFY.Blog.Data.MongoDB.Models;
using OmegaFY.Blog.Domain.Entities.Posts;

namespace OmegaFY.Blog.Data.MongoDB.Extensions;

public static class PostExtensions
{
    public static PostBasicInfoCollectionModel ToPostCollectionModel(this Post post)
    {
        return new PostBasicInfoCollectionModel()
        {
            Id = post.Id,
            AuthorId = post.AuthorId,
            Body = post.Body,
            Header = post.Header,
            ModificationDetails = post.ModificationDetails,
            Private = post.Private
        };
    }
}