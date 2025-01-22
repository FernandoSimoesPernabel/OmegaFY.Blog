using OmegaFY.Blog.Domain.Enums;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Data.MongoDB.Models;

public class ReactionCollectionModel
{
    public ReferenceId Id { get; set; }

    public ReferenceId CommentId { get; set; }

    public ReferenceId AuthorId { get; set; }

    public CommentReaction CommentReaction { get; set; }
}