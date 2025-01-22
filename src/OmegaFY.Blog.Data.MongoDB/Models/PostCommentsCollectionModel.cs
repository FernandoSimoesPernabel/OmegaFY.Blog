using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Data.MongoDB.Models;

public class PostCommentsCollectionModel
{
    public ReferenceId Id { get; set; }

    public CommentCollectionModel[] Comments { get; set; } = [];
}