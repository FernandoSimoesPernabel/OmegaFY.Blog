using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Commands.Shares.SharePost;

public class SharePostCommandResult : GenericResult, ICommandResult
{
    public Guid Id { get; set; }

    public Guid PostId { get; set; }

    public Guid AuthorId { get; set; }

    public DateTime DateAndTimeOfShare { get; set; }

    public SharePostCommandResult() { }

    public SharePostCommandResult(Guid id, Guid postId, Guid authorId, DateTime dateAndTimeOfShare)
    {
        Id = id;
        PostId = postId;
        AuthorId = authorId;
        DateAndTimeOfShare = dateAndTimeOfShare;
    }
}