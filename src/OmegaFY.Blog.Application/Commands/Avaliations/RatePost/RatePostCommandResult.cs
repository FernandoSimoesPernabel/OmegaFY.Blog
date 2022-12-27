using OmegaFY.Blog.Application.Result;
using OmegaFY.Blog.Domain.Enums;

namespace OmegaFY.Blog.Application.Commands.Avaliations.RatePost;

public class RatePostCommandResult : GenericResult, ICommandResult
{
    public Guid Id { get; set; }

    public Guid PostId { get; set; }

    public Guid AuthorId { get; set; }

    public Stars Rate { get; set; }

    public DateTime DateOfCreation { get; set; }

    public RatePostCommandResult() { }

    public RatePostCommandResult(Guid id, Guid postId, Guid authorId, Stars rate, DateTime dateOfCreation)
    {
        Id = id;
        PostId = postId;
        AuthorId = authorId;
        Rate = rate;
        DateOfCreation = dateOfCreation;
    }
}