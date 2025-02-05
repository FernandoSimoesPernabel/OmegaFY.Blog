using OmegaFY.Blog.Data.MongoDB.Models;
using OmegaFY.Blog.Domain.Entities.Users;

namespace OmegaFY.Blog.Data.MongoDB.Extensions;

public static class UserExtensions
{
    public static UserCollectionModel ToUserCollectionModel(this User user)
    {
        return new UserCollectionModel()
        {
            Id = user.Id,
            DisplayName = user.DisplayName,
            Email = user.Email
        };
    }
}