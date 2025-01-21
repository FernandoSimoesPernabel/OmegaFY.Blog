using MongoDB.Bson;
using OmegaFY.Blog.Domain.ValueObjects.Posts;
using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Data.MongoDB.Models;

public class CommentCollectionModel
{
    public ObjectId Id { get; set; }

    public ObjectId PostId { get; }

    public ObjectId AuthorId { get; set; }

    public Body Body { get; set; }

    public ModificationDetails ModificationDetails { get; set; }

    public ReactionCollectionModel[] Reactions { get; set; } = [];
}