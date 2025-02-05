using OmegaFY.Blog.Data.MongoDB.Models;
using OmegaFY.Blog.Domain.Entities.Comments;

namespace OmegaFY.Blog.Data.MongoDB.Extensions;

public static class PostCommentsCollectionModelExtensions
{
    public static PostComments ToPostComments(this PostCommentsCollectionModel postModel)
        => PostComments.Create(postModel.Id, postModel.Comments.ToArrayOfComment());
}