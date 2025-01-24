using OmegaFY.Blog.Data.MongoDB.Models;
using OmegaFY.Blog.Domain.Entities.Comments;

namespace OmegaFY.Blog.Data.MongoDB.Extensions;

public static class CommentCollectionModelExtensions
{
    public static Comment[] ToArrayOfComment(this CommentCollectionModel[] commentModels)
        => commentModels.Select(model => model.ToComment()).ToArray();

    public static Comment ToComment(this CommentCollectionModel commentModel)
    {
        return Comment.Create(
            commentModel.Id,
            commentModel.PostId,
            commentModel.AuthorId,
            commentModel.Body,
            commentModel.ModificationDetails,
            commentModel.Reactions.ToArrayOfReaction());
    }
}