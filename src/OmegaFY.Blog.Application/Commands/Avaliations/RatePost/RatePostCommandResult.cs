using OmegaFY.Blog.Application.Result;
using OmegaFY.Blog.Domain.Enums;

namespace OmegaFY.Blog.Application.Commands.Avaliations.RatePost;

public class RatePostCommandResult : GenericResult, ICommandResult
{
    public Guid Id { get; set; }

    public Guid PostId { get; set; }

    public Guid AuthorId { get; set; }

    public Stars Rate { get; set; }

    public DateTime CreationDate { get; set; }

    public RatePostCommandResult() { }

    public RatePostCommandResult(Guid id, Guid authorId, Stars rate, DateTime creationDate)
    {
        Id = id;
        AuthorId = authorId;
        Rate = rate;
        CreationDate = creationDate;
    }
}