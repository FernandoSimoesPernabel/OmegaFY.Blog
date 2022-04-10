namespace OmegaFY.Blog.Data.EF.Models;

public class PostModel
{
    public Guid Id { get; set; }

    public Guid AuthorId { get; set; }

    public string Title { get; set; }

    public string SubTitle { get; set; }

    public string Content { get; set; }

    public DateTime DateOfCreation { get; set; }

    public DateTime? DateOfModification { get; set; }

    public int AverageRate { get; set; }

    public bool Hidden { get; set; }

    public ICollection<AvaliationModel> Avaliations { get; set; }

    public ICollection<CommentModel> Comments { get; set; }

    public ICollection<SharedModel> Shareds { get; set; }
}