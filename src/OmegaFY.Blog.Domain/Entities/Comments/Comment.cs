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

    internal Reaction FindReactionAndThrowIfNotFound(ReferenceId authorId)
    {
        Reaction reaction = _reactions.FirstOrDefault(reaction => reaction.AuthorId == authorId);

        if (reaction is null)
            throw new NotFoundException();

        return reaction;
    }

    internal bool HasAuthorAlreadyReactToComment(ReferenceId authorId) => _reactions.Any(reaction => reaction.AuthorId == authorId);

    internal void ChangeContent(Body newBody)
    {
        if (newBody.Content.Length > PostConstants.MAX_COMMENT_BODY_LENGTH)
            throw new DomainArgumentException($"O máximo de caracteres de um comentário é {PostConstants.MAX_COMMENT_BODY_LENGTH}.");

        Body = newBody;
        ModificationDetails = new ModificationDetails(ModificationDetails.DateOfCreation);
    }

    internal void React(Reaction reaction)
    {
        if (reaction is null)
            throw new DomainArgumentException("Não foi informada uma reação.");

        if (reaction.CommentId != Id)
            throw new DomainArgumentException("O Id da reação não bate com o comentário atual.");

        _reactions.Add(reaction);
    }

    internal void ChangeReaction(Guid authorId, CommentReaction newCommentReaction)
    {
        Reaction reaction = FindReactionAndThrowIfNotFound(authorId);
        reaction.ChangeCommentReaction(newCommentReaction);
    }

    internal void RemoveReaction(Guid authorId)
    {
        Reaction reaction = FindReactionAndThrowIfNotFound(authorId);
        _reactions.Remove(reaction);
    }
}