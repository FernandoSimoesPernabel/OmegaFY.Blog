﻿using OmegaFY.Blog.Domain.Enums;
using OmegaFY.Blog.Domain.Exceptions;
using OmegaFY.Blog.Domain.ValueObjects.Posts;

namespace OmegaFY.Blog.Domain.Entities.Posts;

public class PostWithComments : Post
{
    private readonly List<Comment> _comments;

    public IReadOnlyCollection<Comment> Comments => _comments.AsReadOnly();

    protected PostWithComments() { }

    public PostWithComments(Author author, Header header, Body body) : base(author, header, body)
    {
        _comments = new List<Comment>();
    }

    public Comment FindCommentAndThrowIfNotFound(Guid commentId)
    {
        Comment comment = _comments.FirstOrDefault(x => x.Id == commentId);

        if (comment is null)
            throw new NotFoundException("");

        return comment;
    }

    public void Comment(Comment comment)
    {
        if (comment is null)
            throw new DomainArgumentException("");

        _comments.Add(comment);
    }

    public void EditComment(Guid commentId, Body body)
    {
        Comment comment = FindCommentAndThrowIfNotFound(commentId);
        comment.EditBodyContent(body);
    }

    public void RemoveComment(Guid commentId)
    {
        Comment comment = FindCommentAndThrowIfNotFound(commentId);
        _comments.Remove(comment);
    }

    public void ReactToComment(Guid commentId, Reaction reaction)
    {
        Comment comment = FindCommentAndThrowIfNotFound(commentId);
        comment.React(reaction);
    }

    public void ChangeReactionToComment(Guid commentId, Guid reactionId, Reactions newCommentReaction)
    {
        Comment comment = FindCommentAndThrowIfNotFound(commentId);
        comment.ChangeReaction(reactionId, newCommentReaction);
    }

    public void RemoveReactionFromComment(Guid commentId, Guid reactionId)
    {
        Comment comment = FindCommentAndThrowIfNotFound(commentId);
        comment.RemoveReaction(reactionId);
    }
}