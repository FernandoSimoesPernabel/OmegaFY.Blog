namespace OmegaFY.Blog.Data.EF.Models;

public class CommentModel
{
    public Guid Id { get; set; }

    public Guid PostId { get; set; }

    public Guid AuthorId { get; set; }

    public string Content { get; set; }

    public DateTime DateOfCreation { get; set; }

    public DateTime? DateOfModification { get; set; }

    public ICollection<ReactionModel> Reactions { get; set; }
}
