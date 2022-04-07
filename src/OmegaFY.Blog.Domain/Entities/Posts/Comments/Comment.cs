using OmegaFY.Blog.Domain.Enums;
using OmegaFY.Blog.Domain.Exceptions;
using OmegaFY.Blog.Domain.ValueObjects.Posts;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Domain.Entities.Posts.Comments;

public class Comment : Entity
{
    private readonly List<Reaction> _reactions;

    public Guid PostId { get; }

    public Author Author { get; }

    public Body Body { get; private set; }

    public ModificationDetails ModificationDetails { get; private set; }

    public IReadOnlyCollection<Reaction> Reactions => _reactions.AsReadOnly();

    protected Comment() { }

    public Comment(Guid postId, Author author, Body body)
    {
        _reactions = new List<Reaction>();

        PostId = postId;
        Author = author;
        Body = body;
        ModificationDetails = new ModificationDetails();
    }

    internal Reaction FindReactionAndThrowIfNotFound(Guid reactionId)
    {
        Reaction reaction = _reactions.FirstOrDefault(x => x.Id == reactionId);

        if (reaction is null)
            throw new NotFoundException("");

        return reaction;
    }

    internal void EditBodyContent(Body newBody)
    {
        if (newBody is null)
            throw new DomainArgumentException("");

        Body = newBody;
        ModificationDetails = new ModificationDetails(ModificationDetails.DateOfCreation);
    }

    internal void React(Reaction reaction)
    {
        if (reaction is null)
            throw new DomainArgumentException("");

        _reactions.Add(reaction);
    }

    internal void ChangeReaction(Guid reactionId, Reactions newCommentReaction)
    {
        Reaction reaction = FindReactionAndThrowIfNotFound(reactionId);
        reaction.ChangeCommentReaction(newCommentReaction);
    }

    internal void RemoveReaction(Guid reactionId)
    {
        Reaction reaction = FindReactionAndThrowIfNotFound(reactionId);
        _reactions.Remove(reaction);
    }
}