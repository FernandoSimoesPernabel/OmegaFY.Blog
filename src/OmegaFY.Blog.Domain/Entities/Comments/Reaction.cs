using OmegaFY.Blog.Common.Extensions;
using OmegaFY.Blog.Domain.Enums;
using OmegaFY.Blog.Domain.Exceptions;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Domain.Entities.Comments;

public class Reaction : Entity
{
    public ReferenceId CommentId { get; }

    public ReferenceId AuthorId { get; }

    public CommentReaction CommentReaction { get; private set; }

    protected Reaction() { }

    public Reaction(ReferenceId commentId, ReferenceId authorId, CommentReaction commentReaction)
    {
        CommentId = commentId;
        AuthorId = authorId;
        ChangeCommentReaction(commentReaction);
    }

    internal void ChangeCommentReaction(CommentReaction commentReaction)
    {
        if (!commentReaction.IsDefined())
            throw new DomainArgumentException("A reação informada não é válida.");

        CommentReaction = commentReaction;
    }
}