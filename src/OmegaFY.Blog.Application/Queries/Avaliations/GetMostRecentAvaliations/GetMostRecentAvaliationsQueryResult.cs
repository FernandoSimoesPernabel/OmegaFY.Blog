using OmegaFY.Blog.Application.Result;
using OmegaFY.Blog.Domain.Enums;

namespace OmegaFY.Blog.Application.Queries.Avaliations.GetMostRecentAvaliations;

public class GetMostRecentAvaliationsQueryResult : GenericResult, IQueryResult
{
    public Guid Id { get; set; }

    public Guid PostId { get; set; }

    public string PostTitle { get; set; }

    public Guid AuthorId { get; set; }

    public string AuthorName { get; set; }

    public Stars Rate { get; set; }

    public DateTime AvaliationDate { get; set; }

    public bool HasAvaliationBeenEdit { get; set; }
}