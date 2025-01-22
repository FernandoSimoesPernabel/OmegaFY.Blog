using OmegaFY.Blog.Data.MongoDB.Models;
using OmegaFY.Blog.Domain.Entities.Users;

namespace OmegaFY.Blog.Data.MongoDB.Extensions;

public static class UserCollectionModelExtensions
{
    public static User ToUser(this UserCollectionModel userModel) => User.Create(userModel.Id.ToGuid(), userModel.Email, userModel.DisplayName);
}