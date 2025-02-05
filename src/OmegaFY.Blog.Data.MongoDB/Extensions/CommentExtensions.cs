using OmegaFY.Blog.Data.MongoDB.Models;
using OmegaFY.Blog.Domain.Entities.Comments;

namespace OmegaFY.Blog.Data.MongoDB.Extensions;

public static class CommentExtensions
{
    public static CommentCollectionModel[] ToArrayOfCommentCollectionModel(this IReadOnlyCollection<Comment> comments)
        => comments.Select(comment => comment.ToCommentCollectionModel()).ToArray();

    public static CommentCollectionModel ToCommentCollectionModel(this Comment comment)
    {
        return new CommentCollectionModel()
        {
            Id = comment.Id,
            AuthorId = comment.AuthorId,
            PostId = comment.PostId,
            Body = comment.Body,
            DateOfCreation = comment.ModificationDetails.DateOfCreation,
            DateOfModification = comment.ModificationDetails.DateOfModification,
            Reactions = comment.Reactions.ToArrayOfReactionCollectionModel()
        };
    }
}