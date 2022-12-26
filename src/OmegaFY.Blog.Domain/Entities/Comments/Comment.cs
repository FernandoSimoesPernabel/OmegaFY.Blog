﻿using OmegaFY.Blog.Common.Exceptions;
using OmegaFY.Blog.Domain.Constantes;
using OmegaFY.Blog.Domain.Enums;
using OmegaFY.Blog.Domain.Exceptions;
using OmegaFY.Blog.Domain.ValueObjects.Posts;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Domain.Entities.Comments;

public class Comment : Entity
{
    private readonly List<Reaction> _reactions;

    public ReferenceId PostId { get; }

    public ReferenceId AuthorId { get; }

    public Body Body { get; private set; }

    public ModificationDetails ModificationDetails { get; private set; }

    public IReadOnlyCollection<Reaction> Reactions => _reactions.AsReadOnly();

    protected Comment() => _reactions = new List<Reaction>();

    public Comment(ReferenceId postId, ReferenceId authorId, Body body) : this()
    {
        ChangeContent(body);
        PostId = postId;
        AuthorId = authorId;
        ModificationDetails = new ModificationDetails();
    }

    internal Reaction FindReactionAndThrowIfNotFound(ReferenceId reactionId, ReferenceId authorId)
    {
        Reaction reaction = _reactions.FirstOrDefault(reaction => reaction.Id == reactionId && reaction.AuthorId == authorId);

        if (reaction is null)
            throw new NotFoundException();

        return reaction;
    }

    internal void ChangeContent(Body body)
    {
        if (body.Content.Length > PostConstants.MAX_COMMENT_BODY_LENGTH)
            throw new DomainArgumentException("");

        Body = body;

        if (ModificationDetails is not null)
            ModificationDetails = new ModificationDetails(ModificationDetails.DateOfCreation);
    }

    internal void React(Reaction reaction)
    {
        if (reaction is null)
            throw new DomainArgumentException("");

        _reactions.Add(reaction);
    }

    internal void ChangeReaction(Guid reactionId, Guid authorId, Reactions newCommentReaction)
    {
        Reaction reaction = FindReactionAndThrowIfNotFound(reactionId, authorId);
        reaction.ChangeCommentReaction(newCommentReaction);
    }

    internal void RemoveReaction(Guid reactionId, Guid authorId)
    {
        Reaction reaction = FindReactionAndThrowIfNotFound(reactionId, authorId);
        _reactions.Remove(reaction);
    }
}