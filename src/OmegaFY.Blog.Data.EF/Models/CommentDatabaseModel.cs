namespace OmegaFY.Blog.Data.EF.Models;

public class CommentDatabaseModel
{
    public Guid Id { get; set; }

    public Guid PostId { get; }

    public PostDatabaseModel Post { get; set; }

    public Guid AuthorId { get; set; }

    public UserDatabaseModel Author { get; set; }

    public string Content { get; set; }

    public DateTime DateOfCreation { get; set; }

    public DateTime? DateOfModification { get; set; }

    public ICollection<ReactionDatabaseModel> Reactions { get; set; }
}