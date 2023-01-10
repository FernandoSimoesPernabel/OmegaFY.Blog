using OmegaFY.Blog.Common.Exceptions;
using OmegaFY.Blog.Domain.Enums;
using OmegaFY.Blog.Domain.Exceptions;
using OmegaFY.Blog.Domain.ValueObjects.Posts;

namespace OmegaFY.Blog.Domain.Entities.Comments;

public class PostComments : Entity, IAggregateRoot<PostComments>
{
    private readonly List<Comment> _comments;

    public IReadOnlyCollection<Comment> Comments => _comments.AsReadOnly();

    protected PostComments() => _comments = new List<Comment>();

    public Comment FindCommentAndThrowIfNotFound(ReferenceId commentId, ReferenceId authorId)
    {
        Comment comment = _comments.FirstOrDefault(x => x.Id == commentId && x.AuthorId == authorId);

        if (comment is null)
            throw new NotFoundException();

        return comment;
    }

    public Reaction FindReactionAndThrowIfNotFound(ReferenceId commentId, ReferenceId authorId)
    {
        Comment comment = FindCommentAndThrowIfNotFound(commentId, authorId);
        return comment.FindReactionAndThrowIfNotFound(authorId);
    }

    public void Comment(Comment comment)
    {
        if (comment is null)
            throw new DomainArgumentException("");

        if (comment.PostId != Id)
            throw new DomainArgumentException("");

        _comments.Add(comment);
    }

    public void EditComment(ReferenceId commentId, ReferenceId authorId, Body newBody)
    {
        Comment comment = FindCommentAndThrowIfNotFound(commentId, authorId);
        comment.ChangeContent(newBody);
    }

    public void RemoveComment(ReferenceId commentId, ReferenceId authorId)
    {
        Comment comment = FindCommentAndThrowIfNotFound(commentId, authorId);
        _comments.Remove(comment);
    }

    public void ReactToComment(ReferenceId commentId, ReferenceId authorId, CommentReaction commentReaction)
    {
        Comment comment = FindCommentAndThrowIfNotFound(commentId, authorId);

        if (comment.HasAuthorAlreadyReactToComment(authorId))
        {
            comment.ChangeReaction(authorId, commentReaction);
            return;
        }

        comment.React(new Reaction(commentId, authorId, commentReaction));
    }

    public void ChangeReactionToComment(ReferenceId commentId, ReferenceId authorId, CommentReaction newCommentReaction)
    {
        Comment comment = FindCommentAndThrowIfNotFound(commentId, authorId);
        comment.ChangeReaction(authorId, newCommentReaction);
    }

    public void RemoveReactionFromComment(ReferenceId commentId, ReferenceId authorId)
    {
        Comment comment = FindCommentAndThrowIfNotFound(commentId, authorId);
        comment.RemoveReaction(authorId);
    }
}