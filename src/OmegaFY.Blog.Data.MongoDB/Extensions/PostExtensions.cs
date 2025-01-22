using OmegaFY.Blog.Data.MongoDB.Models;
using OmegaFY.Blog.Domain.Entities.Posts;

namespace OmegaFY.Blog.Data.MongoDB.Extensions;

public static class PostExtensions
{
    public static PostCollectionModel ToPostCollectionModel(this Post post)
    {
        return new PostCollectionModel()
        {
            Id = post.Id.ToObjectId(),
            AuthorId = post.AuthorId.ToObjectId(),
            Body = post.Body,
            Header = post.Header,
            ModificationDetails = post.ModificationDetails,
            Private = post.Private
        };
    }
}