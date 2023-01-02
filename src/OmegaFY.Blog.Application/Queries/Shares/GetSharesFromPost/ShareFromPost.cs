namespace OmegaFY.Blog.Application.Queries.Shares.GetSharesFromPost;

public class ShareFromPost
{
    public Guid Id { get; set; }

    public Guid PostId { get; set; }

    public Guid AuthorId { get; set; }

    public string AuthorName { get; set; }

    public DateTime DateAndTimeOfShare { get; set; }
}