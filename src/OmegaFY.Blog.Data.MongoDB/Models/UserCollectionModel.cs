using OmegaFY.Blog.Domain.ValueObjects.Shared;

namespace OmegaFY.Blog.Data.MongoDB.Models;

public class UserCollectionModel
{
    public ReferenceId Id { get; set; }

    public string Email { get; set; }

    public string DisplayName { get; set; }
}