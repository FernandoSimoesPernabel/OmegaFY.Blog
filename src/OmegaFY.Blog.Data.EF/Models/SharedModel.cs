namespace OmegaFY.Blog.Data.EF.Models;

public class SharedModel
{
    public Guid Id { get; set; }

    public Guid PostId { get; set; }

    public Guid AuthorId { get; set; }

    public DateTime DateAndTimeOfShare { get; set; }
}