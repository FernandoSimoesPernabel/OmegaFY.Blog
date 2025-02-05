using OmegaFY.Blog.Data.MongoDB.Models;
using OmegaFY.Blog.Domain.Entities.Comments;

namespace OmegaFY.Blog.Data.MongoDB.Extensions;

public static class ReactionExtensions
{
    public static ReactionCollectionModel[] ToArrayOfReactionCollectionModel(this IReadOnlyCollection<Reaction> reactions)
        => reactions.Select(reaction => reaction.ToReactionCollectionModel()).ToArray();

    public static ReactionCollectionModel ToReactionCollectionModel(this Reaction reaction)
    {
        return new ReactionCollectionModel()
        {
            Id = reaction.Id,
            AuthorId = reaction.AuthorId,
            CommentId = reaction.CommentId,
            CommentReaction = reaction.CommentReaction
        };
    }
}