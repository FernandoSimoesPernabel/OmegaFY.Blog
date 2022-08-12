using OmegaFY.Blog.Application.Commands.Avaliations.ChangeUserRating;
using OmegaFY.Blog.Application.Commands.Avaliations.RatePost;
using OmegaFY.Blog.Application.Commands.Avaliations.RemoveRating;
using OmegaFY.Blog.Application.Commands.Comments.ChangeReaction;
using OmegaFY.Blog.Application.Commands.Comments.EditComment;
using OmegaFY.Blog.Application.Commands.Comments.MakeComment;
using OmegaFY.Blog.Application.Commands.Comments.ReactToComment;
using OmegaFY.Blog.Application.Commands.Comments.RemoveComment;
using OmegaFY.Blog.Application.Commands.Comments.RemoveReaction;
using OmegaFY.Blog.Application.Commands.Donations.BuyMeCoffe;
using OmegaFY.Blog.Application.Commands.Posts.ChangePostContent;
using OmegaFY.Blog.Application.Commands.Posts.MakePostPrivate;
using OmegaFY.Blog.Application.Commands.Posts.MakePostPublic;
using OmegaFY.Blog.Application.Commands.Posts.PublishPost;
using OmegaFY.Blog.Application.Commands.Shares.SharePost;
using OmegaFY.Blog.Application.Commands.Shares.UnsharePost;
using OmegaFY.Blog.Application.Commands.Users.ExcludeAccount;
using OmegaFY.Blog.Application.Commands.Users.Login;
using OmegaFY.Blog.Application.Commands.Users.Logoff;
using OmegaFY.Blog.Application.Commands.Users.RefreshToken;
using OmegaFY.Blog.Application.Commands.Users.RegisterNewUser;
using OmegaFY.Blog.Application.Queries.Avaliations.GetTopRatedPosts;
using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.Comments.GetMostReactedComments;
using OmegaFY.Blog.Application.Queries.Comments.GetMostRecentComments;
using OmegaFY.Blog.Application.Queries.Donations.GetDonationsMade;
using OmegaFY.Blog.Application.Queries.Donations.GetDonationsReceived;
using OmegaFY.Blog.Application.Queries.Donations.GetMostRecentDonations;
using OmegaFY.Blog.Application.Queries.Donations.GetTopDonations;
using OmegaFY.Blog.Application.Queries.Posts.GetAllPosts;
using OmegaFY.Blog.Application.Queries.Posts.GetMostRecentPublishedPosts;
using OmegaFY.Blog.Application.Queries.Posts.GetPost;
using OmegaFY.Blog.Application.Queries.Shares.GetMostRecentShares;
using OmegaFY.Blog.WebAPI.Models.Commands;
using OmegaFY.Blog.WebAPI.Models.Queries;
using OmegaFY.Blog.WebAPI.Models.Responses;
using System.Text.Json.Serialization;

namespace OmegaFY.Blog.WebAPI.JsonSerializers;

[JsonSerializable(typeof(BuyMeCoffeInputModel))]
[JsonSerializable(typeof(ChangeUserInputModel))]
[JsonSerializable(typeof(EditCommentInputModel))]
[JsonSerializable(typeof(ChangePostContentInputModel))]
[JsonSerializable(typeof(ExcludeAccountInputModel))]
[JsonSerializable(typeof(LoginInputModel))]
[JsonSerializable(typeof(LogoffInputModel))]
[JsonSerializable(typeof(MakeCommentInputModel))]
[JsonSerializable(typeof(PublishPostInputModel))]
[JsonSerializable(typeof(RatePostInputModel))]
[JsonSerializable(typeof(ReactToCommentInputModel))]
[JsonSerializable(typeof(RefreshTokenInputModel))]
[JsonSerializable(typeof(RegisterNewUserInputModel))]
[JsonSerializable(typeof(RemoveCommentInputModel))]
[JsonSerializable(typeof(RemoveRatingInputModel))]
[JsonSerializable(typeof(RemoveReactionInputModel))]
[JsonSerializable(typeof(SharePostInputModel))]
[JsonSerializable(typeof(UnsharePostInputModel))]
[JsonSerializable(typeof(GetAllPostsInputModel))]
[JsonSerializable(typeof(GetDonationsMadeInputModel))]
[JsonSerializable(typeof(GetDonationsReceivedInputModel))]
[JsonSerializable(typeof(GetMostReactedInputModel))]
[JsonSerializable(typeof(GetMostRecentDonationsInputModel))]
[JsonSerializable(typeof(GetMostRecentInputModel))]
[JsonSerializable(typeof(GetMostRecentPublishedInputModel))]
[JsonSerializable(typeof(GetMostRecentSharesInputModel))]
[JsonSerializable(typeof(GetTopDonationsInputModel))]
[JsonSerializable(typeof(GetTopRatedPostsInputModel))]
[JsonSerializable(typeof(ApiResponse<ChangeUserRatingCommandResult>))]
[JsonSerializable(typeof(ApiResponse<RatePostCommandResult>))]
[JsonSerializable(typeof(ApiResponse<RemoveRatingCommandResult>))]
[JsonSerializable(typeof(ApiResponse<ChangeReactionCommandResult>))]
[JsonSerializable(typeof(ApiResponse<EditCommentCommandResult>))]
[JsonSerializable(typeof(ApiResponse<MakeCommentCommandResult>))]
[JsonSerializable(typeof(ApiResponse<ReactToCommentCommandResult>))]
[JsonSerializable(typeof(ApiResponse<RemoveCommentCommandResult>))]
[JsonSerializable(typeof(ApiResponse<RemoveReactionCommandResult>))]
[JsonSerializable(typeof(ApiResponse<BuyMeCoffeCommandResult>))]
[JsonSerializable(typeof(ApiResponse<ChangePostContentCommandResult>))]
[JsonSerializable(typeof(ApiResponse<MakePostPrivateCommandResult>))]
[JsonSerializable(typeof(ApiResponse<MakePostPublicCommandResult>))]
[JsonSerializable(typeof(ApiResponse<PublishPostCommandResult>))]
[JsonSerializable(typeof(ApiResponse<SharePostCommandResult>))]
[JsonSerializable(typeof(ApiResponse<UnsharePostCommandResult>))]
[JsonSerializable(typeof(ApiResponse<ExcludeAccountCommandResult>))]
[JsonSerializable(typeof(ApiResponse<LoginCommandResult>))]
[JsonSerializable(typeof(ApiResponse<LogoffCommandResult>))]
[JsonSerializable(typeof(ApiResponse<RefreshTokenCommandResult>))]
[JsonSerializable(typeof(ApiResponse<RegisterNewUserCommandResult>))]
[JsonSerializable(typeof(ApiResponse<GetTopRatedPostsQueryResult>))]
[JsonSerializable(typeof(ApiResponse<GetMostReactedCommentsQueryResult>))]
[JsonSerializable(typeof(ApiResponse<GetMostRecentCommentsQueryResult>))]
[JsonSerializable(typeof(ApiResponse<GetDonationsMadeQueryResult>))]
[JsonSerializable(typeof(ApiResponse<GetDonationsReceivedQueryResult>))]
[JsonSerializable(typeof(ApiResponse<GetMostRecentDonationsQueryResult>))]
[JsonSerializable(typeof(ApiResponse<GetTopDonationsQueryResult>))]
[JsonSerializable(typeof(ApiResponse<PagedResult<GetAllPostsQueryResult>>))]
[JsonSerializable(typeof(ApiResponse<GetMostRecentPublishedPostsQueryResult>))]
[JsonSerializable(typeof(ApiResponse<GetPostQueryResult>))]
[JsonSerializable(typeof(ApiResponse<GetMostRecentSharesQueryResult>))]
internal partial class JsonSerializerSourceGeneratorContext : JsonSerializerContext { }