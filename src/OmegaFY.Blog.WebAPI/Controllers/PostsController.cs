using Microsoft.AspNetCore.Mvc;
using OmegaFY.Blog.Application.Bus;
using OmegaFY.Blog.Application.Commands.Avaliations.ChangeUserRating;
using OmegaFY.Blog.Application.Commands.Avaliations.RatePost;
using OmegaFY.Blog.Application.Commands.Avaliations.RemoveRating;
using OmegaFY.Blog.Application.Commands.Posts.ChangePostContent;
using OmegaFY.Blog.Application.Commands.Posts.MakePostPrivate;
using OmegaFY.Blog.Application.Commands.Posts.MakePostPublic;
using OmegaFY.Blog.Application.Commands.Posts.PublishPost;
using OmegaFY.Blog.Application.Commands.Shares.SharePost;
using OmegaFY.Blog.Application.Commands.Shares.UnsharePost;
using OmegaFY.Blog.Application.Queries.Avaliations.GetAvaliation;
using OmegaFY.Blog.Application.Queries.Avaliations.GetTopRatedPosts;
using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.Posts.GetAllPosts;
using OmegaFY.Blog.Application.Queries.Posts.GetMostRecentPublishedPosts;
using OmegaFY.Blog.Application.Queries.Posts.GetPost;
using OmegaFY.Blog.Application.Queries.Shares.CurrentUserHasSharedPost;
using OmegaFY.Blog.Application.Queries.Shares.GetMostRecentShares;
using OmegaFY.Blog.Domain.Enums;
using OmegaFY.Blog.WebAPI.Controllers.Base;
using OmegaFY.Blog.WebAPI.Responses;

namespace OmegaFY.Blog.WebAPI.Controllers;

[ApiVersion("1.0")]
public class PostsController : ApiControllerBase
{
    public PostsController(IServiceBus serviceBus) : base(serviceBus) { }

    [HttpGet()]
    [ProducesResponseType(typeof(ApiResponse<PagedResult<GetAllPostsQueryResult>>), 200)]
    public async Task<IActionResult> GetAllPosts([FromQuery] GetAllPostsQuery query, CancellationToken cancellationToken)
        => Ok(await _serviceBus.SendMessageAsync<GetAllPostsQuery, PagedResult<GetAllPostsQueryResult>>(query, cancellationToken));

    [HttpGet()]
    [ProducesResponseType(typeof(ApiResponse<PagedResult<GetMostRecentPublishedPostsQueryResult>>), 200)]
    public async Task<IActionResult> GetMostRecentPublishedPosts([FromQuery] GetMostRecentPublishedPostsQuery query, CancellationToken cancellationToken)
        => Ok(await _serviceBus.SendMessageAsync<GetMostRecentPublishedPostsQuery, PagedResult<GetMostRecentPublishedPostsQueryResult>>(query, cancellationToken));

    [HttpGet()]
    [ProducesResponseType(typeof(ApiResponse<PagedResult<GetMostRecentSharesQueryResult>>), 200)]
    public async Task<IActionResult> GetMostRecentShares([FromQuery] GetMostRecentSharesQuery query, CancellationToken cancellationToken)
        => Ok(await _serviceBus.SendMessageAsync<GetMostRecentSharesQuery, PagedResult<GetMostRecentSharesQueryResult>>(query, cancellationToken));

    [HttpGet()]
    [ProducesResponseType(typeof(ApiResponse<PagedResult<GetTopRatedPostsQueryResult>>), 200)]
    public async Task<IActionResult> GetTopRatedPostsQueryResult([FromQuery] GetTopRatedPostsQuery query, CancellationToken cancellationToken)
        => Ok(await _serviceBus.SendMessageAsync<GetTopRatedPostsQuery, PagedResult<GetTopRatedPostsQueryResult>>(query, cancellationToken));

    [HttpGet("{Id:guid}")]
    [ProducesResponseType(typeof(ApiResponse<GetPostQueryResult>), 200)]
    [ProducesResponseType(typeof(ApiResponse), 404)]
    public async Task<IActionResult> GetPost([FromRoute] GetPostQuery query, CancellationToken cancellationToken)
        => Ok(await _serviceBus.SendMessageAsync<GetPostQuery, GetPostQueryResult>(query, cancellationToken));

    [HttpPost()]
    [ProducesResponseType(typeof(ApiResponse<PublishPostCommandResult>), 201)]
    [ProducesResponseType(typeof(ApiResponse), 400)]
    public async Task<IActionResult> PublishPost(PublishPostCommand command, CancellationToken cancellationToken)
    {
        PublishPostCommandResult result = await _serviceBus.SendMessageAsync<PublishPostCommand, PublishPostCommandResult>(command, cancellationToken);
        return CreatedAtAction(nameof(GetPost), new { result.Id }, result);
    }

    [HttpPut()]
    [ProducesResponseType(typeof(ApiResponse<ChangePostContentCommandResult>), 200)]
    [ProducesResponseType(typeof(ApiResponse), 400)]
    public async Task<IActionResult> ChangePostContent(ChangePostContentCommand command, CancellationToken cancellationToken)
        => Ok(await _serviceBus.SendMessageAsync<ChangePostContentCommand, ChangePostContentCommandResult>(command, cancellationToken));

    [HttpPatch("{Id:guid}")]
    [ProducesResponseType(typeof(ApiResponse<MakePostPrivateCommandResult>), 200)]
    [ProducesResponseType(typeof(ApiResponse), 400)]
    public async Task<IActionResult> MakePostPrivate([FromRoute] MakePostPrivateCommand command, CancellationToken cancellationToken)
        => Ok(await _serviceBus.SendMessageAsync<MakePostPrivateCommand, MakePostPrivateCommandResult>(command, cancellationToken));

    [HttpPatch("{Id:guid}")]
    [ProducesResponseType(typeof(ApiResponse<MakePostPublicCommandResult>), 200)]
    [ProducesResponseType(typeof(ApiResponse), 400)]
    public async Task<IActionResult> MakePostPublic([FromRoute] MakePostPublicCommand command, CancellationToken cancellationToken)
        => Ok(await _serviceBus.SendMessageAsync<MakePostPublicCommand, MakePostPublicCommandResult>(command, cancellationToken));

    [HttpGet()]
    [ProducesResponseType(typeof(ApiResponse<GetShareQueryResult>), 200)]
    [ProducesResponseType(typeof(ApiResponse), 404)]
    public async Task<IActionResult> GetShare([FromQuery] GetShareQuery query, CancellationToken cancellationToken)
        => Ok(await _serviceBus.SendMessageAsync<GetShareQuery, GetShareQueryResult>(query, cancellationToken));

    [HttpGet("{Id:guid}")]
    [ProducesResponseType(typeof(ApiResponse<CurrentUserHasSharedPostQueryResult>), 200)]
    public async Task<IActionResult> CurrentUserHasSharedPost([FromRoute] CurrentUserHasSharedPostQuery query, CancellationToken cancellationToken)
        => Ok(await _serviceBus.SendMessageAsync<CurrentUserHasSharedPostQuery, CurrentUserHasSharedPostQueryResult>(query, cancellationToken));

    [HttpPost("{Id:guid}")]
    [ProducesResponseType(typeof(ApiResponse<SharePostCommandResult>), 201)]
    [ProducesResponseType(typeof(ApiResponse), 400)]
    public async Task<IActionResult> SharePost([FromRoute] SharePostCommand command, CancellationToken cancellationToken)
    {
        SharePostCommandResult result = await _serviceBus.SendMessageAsync<SharePostCommand, SharePostCommandResult>(command, cancellationToken);
        return CreatedAtAction(nameof(GetShare), new { result.PostId, ShareId = result.Id }, result);
    }

    [HttpDelete()]
    [ProducesResponseType(204)]
    [ProducesResponseType(typeof(ApiResponse), 400)]
    public async Task<IActionResult> UnsharePost([FromQuery] UnsharePostCommand command, CancellationToken cancellationToken)
    {
        UnsharePostCommandResult result = await _serviceBus.SendMessageAsync<UnsharePostCommand, UnsharePostCommandResult>(command, cancellationToken);
        return result.Failed() ? BadRequest(result) : NoContent();
    }

    [HttpGet()]
    [ProducesResponseType(typeof(ApiResponse<GetAvaliationQueryResult>), 200)]
    [ProducesResponseType(typeof(ApiResponse), 404)]
    public async Task<IActionResult> GetAvaliation([FromQuery] GetAvaliationQuery query, CancellationToken cancellationToken)
        => Ok(await _serviceBus.SendMessageAsync<GetAvaliationQuery, GetAvaliationQueryResult>(query, cancellationToken));

    [HttpPost()]
    [ProducesResponseType(typeof(ApiResponse<RatePostCommandResult>), 201)]
    [ProducesResponseType(typeof(ApiResponse), 400)]
    public async Task<IActionResult> RatePost([FromBody] RatePostCommand command, CancellationToken cancellationToken)
    {
        RatePostCommandResult result = await _serviceBus.SendMessageAsync<RatePostCommand, RatePostCommandResult>(command, cancellationToken);
        return CreatedAtAction(nameof(GetAvaliation), new { result.PostId, AvaliationId = result.Id }, result);
    }

    [HttpPut()]
    [ProducesResponseType(typeof(ApiResponse<ChangeUserRatingCommandResult>), 200)]
    [ProducesResponseType(typeof(ApiResponse), 400)]
    public async Task<IActionResult> ChangeUserRating(ChangeUserRatingCommand command, CancellationToken cancellationToken)
        => Ok(await _serviceBus.SendMessageAsync<ChangeUserRatingCommand, ChangeUserRatingCommandResult>(command, cancellationToken));

    [HttpDelete()]
    [ProducesResponseType(204)]
    [ProducesResponseType(typeof(ApiResponse), 400)]
    public async Task<IActionResult> RemoveRating([FromQuery] RemoveRatingCommand command, CancellationToken cancellationToken)
    {
        RemoveRatingCommandResult result = await _serviceBus.SendMessageAsync<RemoveRatingCommand, RemoveRatingCommandResult>(command, cancellationToken);
        return result.Failed() ? BadRequest(result) : NoContent();
    }
}