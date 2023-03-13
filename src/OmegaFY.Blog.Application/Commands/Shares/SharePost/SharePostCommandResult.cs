using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Commands.Shares.SharePost;

public class SharePostCommandResult : GenericResult, ICommandResult
{
    public Guid ShareId { get; }

    public Guid PostId { get; }

    public Guid AuthorId { get; }

    public DateTime DateAndTimeOfShare { get; }

    public SharePostCommandResult(Guid shareId, Guid postId, Guid authorId, DateTime dateAndTimeOfShare)
    {
        ShareId = shareId;
        PostId = postId;
        AuthorId = authorId;
        DateAndTimeOfShare = dateAndTimeOfShare;
    }
}