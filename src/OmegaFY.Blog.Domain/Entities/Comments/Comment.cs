using OmegaFY.Blog.Common.Exceptions;
using OmegaFY.Blog.Domain.Constantes;
using OmegaFY.Blog.Domain.Enums;
using OmegaFY.Blog.Domain.Exceptions;
using OmegaFY.Blog.Domain.ValueObjects.Posts;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Domain.Entities.Comments;

public class Comment : Entity
{
    private readonly List<Reaction> _reactions;

    public Guid PostId { get; }

    public Author Author { get; }

    public Body Body { get; private set; }

    public ModificationDetails ModificationDetails { get; private set; }

    public IReadOnlyCollection<Reaction> Reactions => _reactions.AsReadOnly();

    protected Comment() => _reactions = new List<Reaction>();

    public Comment(Guid postId, Author author, Body body) : this()
    {
        if (postId == Guid.Empty)
            throw new DomainArgumentException("");

        if (author is null)
            throw new DomainArgumentException("");

        ChangeContent(body);
        PostId = postId;
        Author = author;
        ModificationDetails = new ModificationDetails();
    }

    internal Reaction FindReactionAndThrowIfNotFound(Guid reactionId, Guid authorId)
    {
        Reaction reaction = _reactions.FirstOrDefault(x => x.Id == reactionId && x.Author.Id == authorId);

        if (reaction is null)
            throw new NotFoundException();

        return reaction;
    }

    internal void ChangeContent(Body body)
    {
        if (string.IsNullOrWhiteSpace(body?.Content) || body.Content.Length > PostConstants.MAX_COMMENT_BODY_LENGTH)
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