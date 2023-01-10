using OmegaFY.Blog.Common.Extensions;
using OmegaFY.Blog.Domain.Enums;
using OmegaFY.Blog.Domain.Exceptions;
using OmegaFY.Blog.Domain.ValueObjects.Posts;

namespace OmegaFY.Blog.Domain.Entities.Comments;

public class Reaction : Entity
{
    public ReferenceId CommentId { get; }

    public ReferenceId AuthorId { get; }

    public CommentReaction CommentReaction { get; private set; }

    protected Reaction() { }

    public Reaction(ReferenceId commentId, ReferenceId authorId, CommentReaction commentReaction)
    {
        ChangeCommentReaction(commentReaction);
        CommentId = commentId;
        AuthorId = authorId;
    }

    public void ChangeCommentReaction(CommentReaction commentReaction)
    {
        if (!commentReaction.IsDefined())
            throw new DomainArgumentException("");

        CommentReaction = commentReaction;
    }
}