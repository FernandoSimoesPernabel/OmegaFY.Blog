namespace OmegaFY.Blog.Data.MongoDB.Models;

public class CommentCollectionModel
{
    public Guid Id { get; set; }

    public Guid PostId { get; set; }

    public Guid AuthorId { get; set; }

    public string Body { get; set; }

    public DateTime DateOfCreation { get; set; }

    public DateTime? DateOfModification { get; set; }

    public ReactionCollectionModel[] Reactions { get; set; } = [];
}