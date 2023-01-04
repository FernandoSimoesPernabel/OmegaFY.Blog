using OmegaFY.Blog.Domain.Enums;

namespace OmegaFY.Blog.Application.Queries.Avaliations.GetAvaliationsFromPost;

public class AvaliationFromPost
{
    public Guid Id { get; set; }

    public Guid PostId { get; set; }

    public string PostTitle { get; set; }

    public Guid AuthorId { get; set; }

    public string AuthorName { get; set; }

    public Stars Rate { get; set; }

    public DateTime DateOfCreation { get; set; }

    public DateTime? DateOfModification { get; set; }
}