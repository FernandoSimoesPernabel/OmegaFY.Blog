using OmegaFY.Blog.Domain.Enums;

namespace OmegaFY.Blog.Data.MongoDB.Models;

public class ReactionCollectionModel
{
    public Guid Id { get; set; }

    public Guid CommentId { get; set; }

    public Guid AuthorId { get; set; }

    public CommentReaction CommentReaction { get; set; }
}