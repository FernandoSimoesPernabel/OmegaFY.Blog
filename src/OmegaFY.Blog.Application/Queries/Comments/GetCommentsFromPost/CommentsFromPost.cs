namespace OmegaFY.Blog.Application.Queries.Comments.GetCommentsFromPostsFromPost;

public sealed record class CommentFromPost
{
    public Guid CommentId { get; set; }

    public Guid PostId { get; set; }

    public Guid CommentAuthorId { get; set; }

    public string CommentAuthorName { get; set; }

    public string Content { get; set; }

    public DateTime DateOfCreation { get; set; }

    public bool HasCommentBeenEdit { get; set; }

    public int Reactions { get; set; }
}