using OmegaFY.Blog.Application.Result;

namespace OmegaFY.Blog.Application.Queries.Comments.GetMostRecentComments;

public class GetMostRecentCommentsQueryResult : GenericResult, IQueryResult
{
    public Guid CommentId { get; set; }

    public Guid PostId { get; set; }

    public Guid CommentAuthorId { get; set; }

    public string CommentAuthorName { get; set; }

    public string Content { get; set; }

    public DateTime DateOfCreation { get; set; }

    public DateTime? DateOfModification { get; set; }

    public int Reactions { get; set; }
}