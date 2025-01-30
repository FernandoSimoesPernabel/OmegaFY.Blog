namespace OmegaFY.Blog.Data.MongoDB.Models;

public class PostCollectionModel
{
    public Guid Id { get; set; }

    public Guid AuthorId { get; set; }

    public string Title { get; set; }

    public string SubTitle { get; set; }

    public string Body { get; set; }

    public DateTime DateOfCreation { get; set; }

    public DateTime? DateOfModification { get; set; }

    public bool Private { get; set; }

    public double AverageRate { get; set; }

    public AvaliationCollectionModel[] Avaliations { get; set; } = [];

    public CommentCollectionModel[] Comments { get; set; } = [];

    public SharedCollectionModel[] Shareds { get; set; } = [];
}