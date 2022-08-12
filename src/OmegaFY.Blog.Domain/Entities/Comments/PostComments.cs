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

    public void Comment(Comment comment)
    {
        if (comment is null)
            throw new DomainArgumentException("");

        _comments.Add(comment);
    }

    public void EditComment(Guid commentId, Guid authorId, Body body)
    {
        Comment comment = FindCommentAndThrowIfNotFound(commentId, authorId);
        comment.ChangeContent(body);
    }

    public void RemoveComment(Guid commentId, Guid authorId)
    {
        Comment comment = FindCommentAndThrowIfNotFound(commentId, authorId);
        _comments.Remove(comment);
    }

    public void ReactToComment(Guid commentId, Guid authorId, Reaction reaction)
    {
        Comment comment = FindCommentAndThrowIfNotFound(commentId, authorId);
        comment.React(reaction);
    }

    public void ChangeReactionToComment(Guid commentId, Guid authorId, Guid reactionId, Reactions newCommentReaction)
    {
        Comment comment = FindCommentAndThrowIfNotFound(commentId, authorId);
        comment.ChangeReaction(reactionId, authorId, newCommentReaction);
    }

    public void RemoveReactionFromComment(Guid commentId, Guid authorId, Guid reactionId)
    {
        Comment comment = FindCommentAndThrowIfNotFound(commentId, authorId);
        comment.RemoveReaction(reactionId, authorId);
    }

    internal Comment FindCommentAndThrowIfNotFound(Guid commentId, Guid authorId)
    {
        Comment comment = _comments.FirstOrDefault(x => x.Id == commentId && x.Author.Id == authorId);

        if (comment is null)
            throw new NotFoundException();

        return comment;
    }
}