namespace OmegaFY.Blog.Data.MongoDB.Models;

public class SharedCollectionModel
{
    public Guid Id { get; set; }

    public Guid PostId { get; set; }

    public Guid AuthorId { get; set; }

    public DateTime DateAndTimeOfShare { get; set; }
}