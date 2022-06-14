using OmegaFY.Blog.Application.Commands.Posts.PublishPost;
using OmegaFY.Blog.Application.Commands.Users.Login;
using OmegaFY.Blog.Application.Commands.Users.Logoff;
using OmegaFY.Blog.Application.Commands.Users.RefreshToken;
using OmegaFY.Blog.Application.Commands.Users.RegisterNewUser;
using OmegaFY.Blog.Application.Queries.Pagination;
using OmegaFY.Blog.Application.Queries.Posts.GetAllPosts;
using OmegaFY.Blog.Application.Queries.Posts.GetPost;
using OmegaFY.Blog.WebAPI.Models.Commands;
using OmegaFY.Blog.WebAPI.Models.Queries;
using OmegaFY.Blog.WebAPI.Models.Responses;
using System.Text.Json.Serialization;

namespace OmegaFY.Blog.WebAPI.JsonSerializers;


[JsonSerializable(typeof(LoginInputModel))]
[JsonSerializable(typeof(LogoffInputModel))]
[JsonSerializable(typeof(PublishPostInputModel))]
[JsonSerializable(typeof(RefreshTokenInputModel))]
[JsonSerializable(typeof(RegisterNewUserInputModel))]
[JsonSerializable(typeof(GetAllPostsInputModel))]
[JsonSerializable(typeof(ApiResponse<RegisterNewUserCommandResult>))]
[JsonSerializable(typeof(ApiResponse<LoginCommandResult>))]
[JsonSerializable(typeof(ApiResponse<LogoffCommandResult>))]
[JsonSerializable(typeof(ApiResponse<RefreshTokenCommandResult>))]
[JsonSerializable(typeof(ApiResponse<PagedResult<GetAllPostsQueryResult>>))]
[JsonSerializable(typeof(ApiResponse<GetPostQueryResult>))]
[JsonSerializable(typeof(ApiResponse<PublishPostCommandResult>))]
internal partial class JsonSerializerSourceGeneratorContext : JsonSerializerContext { }