namespace OmegaFY.Blog.Data.EF.Models;

public class SharedDatabaseModel
{
    public Guid Id { get; set; }

    public Guid PostId { get; set; }

    public PostDatabaseModel Post { get; set; }

    public Guid AuthorId { get; set; }

    public UserDatabaseModel Author { get; set; }

    public DateTime DateAndTimeOfShare { get; set; }
}