using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Commands.Shares.SharePost;

public class SharePostCommandResult : GenericResult, ICommandResult
{
    public Guid ShareId { get; set; }

    public Guid PostId { get; set; }

    public Guid AuthorId { get; set; }

    public DateTime DateAndTimeOfShare { get; set; }

    public SharePostCommandResult() { }

    public SharePostCommandResult(Guid shareId, Guid postId, Guid authorId, DateTime dateAndTimeOfShare)
    {
        ShareId = shareId;
        PostId = postId;
        AuthorId = authorId;
        DateAndTimeOfShare = dateAndTimeOfShare;
    }
}