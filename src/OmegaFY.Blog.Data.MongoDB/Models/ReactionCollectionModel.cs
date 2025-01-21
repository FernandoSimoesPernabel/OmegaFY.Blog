using MongoDB.Bson;
using OmegaFY.Blog.Domain.Enums;

namespace OmegaFY.Blog.Data.MongoDB.Models;

public class ReactionCollectionModel
{
    public ObjectId Id { get; set; }

    public ObjectId CommentId { get; set; }

    public ObjectId AuthorId { get; set; }

    public CommentReaction CommentReaction { get; set; }
}