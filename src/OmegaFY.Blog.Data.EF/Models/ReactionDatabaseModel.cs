using OmegaFY.Blog.Domain.Enums;

namespace OmegaFY.Blog.Data.EF.Models;

public class ReactionDatabaseModel
{
    public Guid Id { get; set; }

    public Guid CommentId { get; set; }

    public Guid AuthorId { get; set; }

    public UserDatabaseModel Author { get; set; }

    public Reactions CommentReaction { get; set; }
}