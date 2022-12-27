using OmegaFY.Blog.Application.Result;
using OmegaFY.Blog.Domain.Enums;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Application.Queries.Avaliations.GetAvaliation;

public class GetAvaliationQueryResult : GenericResult, IQueryResult
{
    public Guid Id { get; set; }

    public Guid PostId { get; set; }

    public Guid AuthorId { get; set; }

    public Stars Rate { get; set; }

    public DateTime DateOfCreation { get; set; }

    public DateTime? DateOfModification { get; set; }

    public GetAvaliationQueryResult() { }

    public GetAvaliationQueryResult(Guid id, Guid postId, Guid authorId, Stars rate, DateTime dateOfCreation, DateTime? dateOfModification)
    {
        Id = id;
        PostId = postId;
        AuthorId = authorId;
        Rate = rate;
        DateOfCreation = dateOfCreation;
        DateOfModification = dateOfModification;
    }
}