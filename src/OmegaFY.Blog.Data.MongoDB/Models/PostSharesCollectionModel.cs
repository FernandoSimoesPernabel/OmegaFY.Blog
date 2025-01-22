using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Data.MongoDB.Models;

public class PostSharesCollectionModel
{
    public ReferenceId Id { get; set; }

    public SharedCollectionModel[] Shareds { get; set; } = [];
}