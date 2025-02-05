using OmegaFY.Blog.Data.MongoDB.Models;
using OmegaFY.Blog.Domain.Entities.Comments;

namespace OmegaFY.Blog.Data.MongoDB.Extensions;

public static class ReactionCollectionModelExtensions
{
    public static Reaction[] ToArrayOfReaction(this ReactionCollectionModel[] reactionModels)
        => reactionModels.Select(model => model.ToReaction()).ToArray();

    public static Reaction ToReaction(this ReactionCollectionModel reactionModel)
        => Reaction.Create(reactionModel.Id, reactionModel.CommentId, reactionModel.AuthorId, reactionModel.CommentReaction);
}