using OmegaFY.Blog.Domain.ValueObjects.Posts;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Data.MongoDB.Models;

public class CommentCollectionModel
{
    public ReferenceId Id { get; set; }

    public ReferenceId PostId { get; }

    public ReferenceId AuthorId { get; set; }

    public Body Body { get; set; }

    public ModificationDetails ModificationDetails { get; set; }

    public ReactionCollectionModel[] Reactions { get; set; } = [];
}