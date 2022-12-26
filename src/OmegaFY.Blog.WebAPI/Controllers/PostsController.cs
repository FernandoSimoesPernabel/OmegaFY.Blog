using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OmegaFY.Blog.Application.Bus;
using OmegaFY.Blog.Application.Commands.Posts.ChangePostContent;
using OmegaFY.Blog.Application.Commands.Posts.MakePostPrivate;
using OmegaFY.Blog.Application.Commands.Posts.MakePostPublic;
using OmegaFY.Blog.Application.Commands.Posts.PublishPost;
using OmegaFY.Blog.Application.Commands.Shares.SharePost;
using OmegaFY.Blog.Application.Commands.Shares.UnsharePost;
using OmegaFY.Blog.Application.Queries.Avaliations.GetTopRatedPosts;
using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.Posts.GetAllPosts;
using OmegaFY.Blog.Application.Queries.Posts.GetMostRecentPublishedPosts;
using OmegaFY.Blog.Application.Queries.Posts.GetPost;
using OmegaFY.Blog.Application.Queries.Shares.CurrentUserHasSharedPost;
using OmegaFY.Blog.Application.Queries.Shares.GetMostRecentShares;
using OmegaFY.Blog.Domain.Entities.Shares;
using OmegaFY.Blog.WebAPI.Controllers.Base;
using OmegaFY.Blog.WebAPI.Models.Commands;
using OmegaFY.Blog.WebAPI.Models.Queries;
using OmegaFY.Blog.WebAPI.Models.Responses;

namespace OmegaFY.Blog.WebAPI.Controllers;

[ApiVersion("1.0")]
public class PostsController : ApiControllerBase
{
    public PostsController(IServiceBus serviceBus) : base(serviceBus) { }

    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<PagedResult<GetAllPostsQueryResult>>), 200)]
    public async Task<IActionResult> GetAllPosts([FromQuery] GetAllPostsInputModel inputModel, CancellationToken cancellationToken)
    {
        PagedResult<GetAllPostsQueryResult> result = await _serviceBus.SendMessageAsync<GetAllPostsQuery, PagedResult<GetAllPostsQueryResult>>(inputModel.ToQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpGet("MostRecentPublishedPosts")]
    [ProducesResponseType(typeof(ApiResponse<PagedResult<GetMostRecentPublishedPostsQueryResult>>), 200)]
    public async Task<IActionResult> GetMostRecentPublishedPosts([FromQuery] GetMostRecentPublishedPostsInputModel inputModel, CancellationToken cancellationToken)
    {
        PagedResult<GetMostRecentPublishedPostsQueryResult> result = await _serviceBus.SendMessageAsync<GetMostRecentPublishedPostsQuery, PagedResult<GetMostRecentPublishedPostsQueryResult>>(inputModel.ToQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpGet("MostRecentShares")]
    [ProducesResponseType(typeof(ApiResponse<PagedResult<GetMostRecentSharesQueryResult>>), 200)]
    public async Task<IActionResult> GetMostRecentShares([FromQuery] GetMostRecentSharesInputModel inputModel, CancellationToken cancellationToken)
    {
        PagedResult<GetMostRecentSharesQueryResult> result = await _serviceBus.SendMessageAsync<GetMostRecentSharesQuery, PagedResult<GetMostRecentSharesQueryResult>>(inputModel.ToQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpGet("TopRatedPosts")]
    [ProducesResponseType(typeof(ApiResponse<PagedResult<GetTopRatedPostsQueryResult>>), 200)]
    public async Task<IActionResult> GetTopRatedPostsQueryResult([FromQuery] GetTopRatedPostsInputModel inputModel, CancellationToken cancellationToken)
    {
        PagedResult<GetTopRatedPostsQueryResult> result = await _serviceBus.SendMessageAsync<GetTopRatedPostsQuery, PagedResult<GetTopRatedPostsQueryResult>>(inputModel.ToQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ApiResponse<GetPostQueryResult>), 200)]
    [ProducesResponseType(typeof(ApiResponse), 404)]
    public async Task<IActionResult> GetPost([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        GetPostQueryResult result = await _serviceBus.SendMessageAsync<GetPostQuery, GetPostQueryResult>(new(id), cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<PublishPostCommandResult>), 201)]
    [ProducesResponseType(typeof(ApiResponse), 400)]
    public async Task<IActionResult> PublishPost(PublishPostInputModel inputModel, CancellationToken cancellationToken)
    {
        PublishPostCommandResult result = await _serviceBus.SendMessageAsync<PublishPostCommand, PublishPostCommandResult>(inputModel.ToCommand(), cancellationToken);
        return CreatedAtAction(nameof(GetPost), new { id = result.Id }, result);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(ApiResponse<ChangePostContentCommandResult>), 200)]
    [ProducesResponseType(typeof(ApiResponse), 400)]
    public async Task<IActionResult> ChangePostContent(Guid id, ChangePostContentInputModel inputModel, CancellationToken cancellationToken)
    {
        ChangePostContentCommandResult result = await _serviceBus.SendMessageAsync<ChangePostContentCommand, ChangePostContentCommandResult>(inputModel.ToCommand(id), cancellationToken);
        return Ok(result);
    }

    [HttpPatch("{id:guid}/MakePrivate")]
    [ProducesResponseType(typeof(ApiResponse<MakePostPrivateCommandResult>), 200)]
    [ProducesResponseType(typeof(ApiResponse), 400)]
    public async Task<IActionResult> MakePostPrivate(Guid id, CancellationToken cancellationToken)
    {
        MakePostPrivateCommandResult result = await _serviceBus.SendMessageAsync<MakePostPrivateCommand, MakePostPrivateCommandResult>(new(id), cancellationToken);
        return Ok(result);
    }

    [HttpPatch("{id:guid}/MakePublic")]
    [ProducesResponseType(typeof(ApiResponse<MakePostPublicCommandResult>), 200)]
    [ProducesResponseType(typeof(ApiResponse), 400)]
    public async Task<IActionResult> MakePostPublic(Guid id, CancellationToken cancellationToken)
    {
        MakePostPublicCommandResult result = await _serviceBus.SendMessageAsync<MakePostPublicCommand, MakePostPublicCommandResult>(new(id), cancellationToken);
        return Ok(result);
    }

    [HttpGet("{PostId:guid}/Shares/{ShareId:guid}")]
    [ProducesResponseType(typeof(ApiResponse<GetShareQueryResult>), 200)]
    [ProducesResponseType(typeof(ApiResponse), 404)]
    public async Task<IActionResult> GetShare([FromRoute] GetShareInputModel inputModel, CancellationToken cancellationToken)
    {
        GetShareQueryResult result = await _serviceBus.SendMessageAsync<GetShareQuery, GetShareQueryResult>(inputModel.ToCommand(), cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id:guid}/Shares/CurrentUserHasSharedPost")]
    [ProducesResponseType(typeof(ApiResponse<CurrentUserHasSharedPostQueryResult>), 200)]
    public async Task<IActionResult> CurrentUserHasSharedPost([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        CurrentUserHasSharedPostQueryResult result = await _serviceBus.SendMessageAsync<CurrentUserHasSharedPostQuery, CurrentUserHasSharedPostQueryResult>(new(id), cancellationToken);
        return Ok(result);
    }

    [HttpPost("{id:guid}/Shares")]
    [ProducesResponseType(typeof(ApiResponse<SharePostCommandResult>), 201)]
    [ProducesResponseType(typeof(ApiResponse), 400)]
    public async Task<IActionResult> SharePost(Guid id, CancellationToken cancellationToken)
    {
        SharePostCommandResult result = await _serviceBus.SendMessageAsync<SharePostCommand, SharePostCommandResult>(new(id), cancellationToken);
        return CreatedAtAction(nameof(GetShare), new { postId = result.PostId, shareId = result.Id }, result);
    }

    [HttpDelete("{PostId:guid}/Shares/{ShareId:guid}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(typeof(ApiResponse), 400)]
    public async Task<IActionResult> UnsharePost([FromRoute] UnsharePostInputModel inputModel, CancellationToken cancellationToken)
    {
        UnsharePostCommandResult result = await _serviceBus.SendMessageAsync<UnsharePostCommand, UnsharePostCommandResult>(inputModel.ToCommand(), cancellationToken);
        return result.Failed() ? BadRequest(result) : NoContent();
    }



}