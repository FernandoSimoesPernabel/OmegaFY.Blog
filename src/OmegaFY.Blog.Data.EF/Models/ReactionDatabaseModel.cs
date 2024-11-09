using OmegaFY.Blog.Domain.Enums;

namespace OmegaFY.Blog.Data.EF.Models;

public class ReactionDatabaseModel
{
    public Guid Id { get; set; }

    public Guid CommentId { get; set; }

    public Guid AuthorId { get; set; }

    public UserDatabaseModel Author { get; set; }

    public CommentDatabaseModel Comment { get; set; }

    public CommentReaction CommentReaction { get; set; }
}