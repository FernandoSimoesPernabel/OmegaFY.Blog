using Microsoft.AspNetCore.Mvc;
using OmegaFY.Blog.Application.Bus;
using OmegaFY.Blog.Application.Commands.Avaliations.RatePost;
using OmegaFY.Blog.Application.Commands.Avaliations.RemoveRating;
using OmegaFY.Blog.Application.Commands.Comments.EditComment;
using OmegaFY.Blog.Application.Commands.Comments.MakeComment;
using OmegaFY.Blog.Application.Commands.Comments.ReactToComment;
using OmegaFY.Blog.Application.Commands.Comments.RemoveComment;
using OmegaFY.Blog.Application.Commands.Posts.ChangePostContent;
using OmegaFY.Blog.Application.Commands.Posts.MakePostPrivate;
using OmegaFY.Blog.Application.Commands.Posts.MakePostPublic;
using OmegaFY.Blog.Application.Commands.Posts.PublishPost;
using OmegaFY.Blog.Application.Commands.Shares.SharePost;
using OmegaFY.Blog.Application.Commands.Shares.UnsharePost;
using OmegaFY.Blog.Application.Queries.Avaliations.GetAvaliationsFromPost;
using OmegaFY.Blog.Application.Queries.Avaliations.GetMostRecentAvaliations;
using OmegaFY.Blog.Application.Queries.Avaliations.GetTopRatedPosts;
using OmegaFY.Blog.Application.Queries.Base.Pagination;
using OmegaFY.Blog.Application.Queries.Comments.GetComment;
using OmegaFY.Blog.Application.Queries.Comments.GetCommentsFromPostsFromPost;
using OmegaFY.Blog.Application.Queries.Comments.GetMostReactedComments;
using OmegaFY.Blog.Application.Queries.Comments.GetMostRecentComments;
using OmegaFY.Blog.Application.Queries.Comments.GetReactionsFromPost;
using OmegaFY.Blog.Application.Queries.Posts.GetAllPosts;
using OmegaFY.Blog.Application.Queries.Posts.GetMostRecentPublishedPosts;
using OmegaFY.Blog.Application.Queries.Posts.GetPost;
using OmegaFY.Blog.Application.Queries.Shares.CurrentUserHasSharedPost;
using OmegaFY.Blog.Application.Queries.Shares.GetMostRecentShares;
using OmegaFY.Blog.Application.Queries.Shares.GetSharesFromPost;
using OmegaFY.Blog.WebAPI.Controllers.Base;
using OmegaFY.Blog.WebAPI.Responses;

namespace OmegaFY.Blog.WebAPI.Controllers;

[ApiVersion("1.0")]
public class PostsController : ApiControllerBase
{
    public PostsController(IServiceBus serviceBus) : base(serviceBus) { }

    [HttpGet()]
    [ProducesResponseType(typeof(ApiResponse<PagedResult<GetAllPostsQueryResult>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllPosts([FromQuery] GetAllPostsQuery query, CancellationToken cancellationToken)
        => Ok(await _serviceBus.SendMessageAsync<GetAllPostsQuery, PagedResult<GetAllPostsQueryResult>>(query, cancellationToken));

    [HttpGet()]
    [ProducesResponseType(typeof(ApiResponse<PagedResult<GetMostRecentPublishedPostsQueryResult>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMostRecentPublishedPosts([FromQuery] GetMostRecentPublishedPostsQuery query, CancellationToken cancellationToken)
        => Ok(await _serviceBus.SendMessageAsync<GetMostRecentPublishedPostsQuery, PagedResult<GetMostRecentPublishedPostsQueryResult>>(query, cancellationToken));

    [HttpGet()]
    [ProducesResponseType(typeof(ApiResponse<PagedResult<GetMostRecentSharesQueryResult>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMostRecentShares([FromQuery] GetMostRecentSharesQuery query, CancellationToken cancellationToken)
        => Ok(await _serviceBus.SendMessageAsync<GetMostRecentSharesQuery, PagedResult<GetMostRecentSharesQueryResult>>(query, cancellationToken));

    [HttpGet()]
    [ProducesResponseType(typeof(ApiResponse<PagedResult<GetMostRecentAvaliationsQueryResult>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMostRecentAvaliations([FromQuery] GetMostRecentAvaliationsQuery query, CancellationToken cancellationToken)
        => Ok(await _serviceBus.SendMessageAsync<GetMostRecentAvaliationsQuery, PagedResult<GetMostRecentAvaliationsQueryResult>>(query, cancellationToken));

    [HttpGet()]
    [ProducesResponseType(typeof(ApiResponse<PagedResult<GetTopRatedPostsQueryResult>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTopRatedPosts([FromQuery] GetTopRatedPostsQuery query, CancellationToken cancellationToken)
        => Ok(await _serviceBus.SendMessageAsync<GetTopRatedPostsQuery, PagedResult<GetTopRatedPostsQueryResult>>(query, cancellationToken));

    [HttpGet()]
    [ProducesResponseType(typeof(ApiResponse<PagedResult<GetMostReactedCommentsQueryResult>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMostReactedCommentsQuery([FromQuery] GetMostReactedCommentsQuery query, CancellationToken cancellationToken)
        => Ok(await _serviceBus.SendMessageAsync<GetMostReactedCommentsQuery, PagedResult<GetMostReactedCommentsQueryResult>>(query, cancellationToken));

    [HttpGet()]
    [ProducesResponseType(typeof(ApiResponse<PagedResult<GetMostRecentCommentsQueryResult>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMostRecentComments([FromQuery] GetMostRecentCommentsQuery query, CancellationToken cancellationToken)
        => Ok(await _serviceBus.SendMessageAsync<GetMostRecentCommentsQuery, PagedResult<GetMostRecentCommentsQueryResult>>(query, cancellationToken));

    [HttpGet("{Id:guid}")]
    [ProducesResponseType(typeof(ApiResponse<GetPostQueryResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPost([FromRoute] GetPostQuery query, CancellationToken cancellationToken)
        => Ok(await _serviceBus.SendMessageAsync<GetPostQuery, GetPostQueryResult>(query, cancellationToken));

    [HttpPost()]
    [ProducesResponseType(typeof(ApiResponse<PublishPostCommandResult>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PublishPost(PublishPostCommand command, CancellationToken cancellationToken)
    {
        PublishPostCommandResult result = await _serviceBus.SendMessageAsync<PublishPostCommand, PublishPostCommandResult>(command, cancellationToken);
        return CreatedAtAction(nameof(GetPost), new { result.Id }, result);
    }

    [HttpPut()]
    [ProducesResponseType(typeof(ApiResponse<ChangePostContentCommandResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ChangePostContent(ChangePostContentCommand command, CancellationToken cancellationToken)
        => Ok(await _serviceBus.SendMessageAsync<ChangePostContentCommand, ChangePostContentCommandResult>(command, cancellationToken));

    [HttpPatch("{Id:guid}")]
    [ProducesResponseType(typeof(ApiResponse<MakePostPrivateCommandResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> MakePostPrivate([FromRoute] MakePostPrivateCommand command, CancellationToken cancellationToken)
        => Ok(await _serviceBus.SendMessageAsync<MakePostPrivateCommand, MakePostPrivateCommandResult>(command, cancellationToken));

    [HttpPatch("{Id:guid}")]
    [ProducesResponseType(typeof(ApiResponse<MakePostPublicCommandResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> MakePostPublic([FromRoute] MakePostPublicCommand command, CancellationToken cancellationToken)
        => Ok(await _serviceBus.SendMessageAsync<MakePostPublicCommand, MakePostPublicCommandResult>(command, cancellationToken));

    [HttpGet("{Id:guid}")]
    [ProducesResponseType(typeof(ApiResponse<GetSharesFromPostQueryResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetSharesFromPost([FromRoute] GetSharesFromPostQuery query, CancellationToken cancellationToken)
        => Ok(await _serviceBus.SendMessageAsync<GetSharesFromPostQuery, GetSharesFromPostQueryResult>(query, cancellationToken));

    [HttpGet("{Id:guid}")]
    [ProducesResponseType(typeof(ApiResponse<CurrentUserHasSharedPostQueryResult>), StatusCodes.Status200OK)]
    public async Task<IActionResult> CurrentUserHasSharedPost([FromRoute] CurrentUserHasSharedPostQuery query, CancellationToken cancellationToken)
        => Ok(await _serviceBus.SendMessageAsync<CurrentUserHasSharedPostQuery, CurrentUserHasSharedPostQueryResult>(query, cancellationToken));

    [HttpPost("{Id:guid}")]
    [ProducesResponseType(typeof(ApiResponse<SharePostCommandResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status409Conflict)]
    public async Task<IActionResult> SharePost([FromRoute] SharePostCommand command, CancellationToken cancellationToken)
        => Ok(await _serviceBus.SendMessageAsync<SharePostCommand, SharePostCommandResult>(command, cancellationToken));

    [HttpDelete()]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UnsharePost([FromQuery] UnsharePostCommand command, CancellationToken cancellationToken)
    {
        UnsharePostCommandResult result = await _serviceBus.SendMessageAsync<UnsharePostCommand, UnsharePostCommandResult>(command, cancellationToken);
        return result.Failed() ? BadRequest(result) : NoContent();
    }

    [HttpGet("{Id:guid}")]
    [ProducesResponseType(typeof(ApiResponse<GetAvaliationsFromPostQueryResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAvaliationsFromPost([FromRoute] GetAvaliationsFromPostQuery query, CancellationToken cancellationToken)
        => Ok(await _serviceBus.SendMessageAsync<GetAvaliationsFromPostQuery, GetAvaliationsFromPostQueryResult>(query, cancellationToken));

    [HttpPut()]
    [ProducesResponseType(typeof(ApiResponse<RatePostCommandResult>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RatePost([FromBody] RatePostCommand command, CancellationToken cancellationToken)
        => Ok(await _serviceBus.SendMessageAsync<RatePostCommand, RatePostCommandResult>(command, cancellationToken));

    [HttpDelete()]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoveRating([FromQuery] RemoveRatingCommand command, CancellationToken cancellationToken)
    {
        RemoveRatingCommandResult result = await _serviceBus.SendMessageAsync<RemoveRatingCommand, RemoveRatingCommandResult>(command, cancellationToken);
        return result.Failed() ? BadRequest(result) : NoContent();
    }

    [HttpGet()]
    [ProducesResponseType(typeof(ApiResponse<GetCommentQueryResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetComment([FromQuery] GetCommentQuery query, CancellationToken cancellationToken)
        => Ok(await _serviceBus.SendMessageAsync<GetCommentQuery, GetCommentQueryResult>(query, cancellationToken));

    [HttpGet("{Id:guid}")]
    [ProducesResponseType(typeof(ApiResponse<GetCommentsFromPostQueryResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCommentsFromPost([FromRoute] GetCommentsFromPostQuery query, CancellationToken cancellationToken)
        => Ok(await _serviceBus.SendMessageAsync<GetCommentsFromPostQuery, GetCommentsFromPostQueryResult>(query, cancellationToken));

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<MakeCommentCommandResult>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> MakeComment(MakeCommentCommand command, CancellationToken cancellationToken)
    {
        MakeCommentCommandResult result = await _serviceBus.SendMessageAsync<MakeCommentCommand, MakeCommentCommandResult>(command, cancellationToken);
        return CreatedAtAction(nameof(GetComment), new { result.PostId, CommentId = result.Id }, result);
    }

    [HttpPut()]
    [ProducesResponseType(typeof(ApiResponse<EditCommentCommandResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> EditComment(EditCommentCommand command, CancellationToken cancellationToken)
        => Ok(await _serviceBus.SendMessageAsync<EditCommentCommand, EditCommentCommandResult>(command, cancellationToken));

    [HttpDelete()]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoveComment([FromQuery] RemoveCommentCommand command, CancellationToken cancellationToken)
    {
        RemoveCommentCommandResult result = await _serviceBus.SendMessageAsync<RemoveCommentCommand, RemoveCommentCommandResult>(command, cancellationToken);
        return result.Failed() ? BadRequest(result) : NoContent();
    }

    [HttpGet("{Id:guid}")]
    [ProducesResponseType(typeof(ApiResponse<GetReactionsFromPostQueryResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetReactionsFromPost([FromRoute] GetReactionsFromPostQuery query, CancellationToken cancellationToken)
        => Ok(await _serviceBus.SendMessageAsync<GetReactionsFromPostQuery, GetReactionsFromPostQueryResult>(query, cancellationToken));

    [HttpPut]
    [ProducesResponseType(typeof(ApiResponse<ReactToCommentCommandResult>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ReactToComment(ReactToCommentCommand command, CancellationToken cancellationToken)
        => Ok(await _serviceBus.SendMessageAsync<ReactToCommentCommand, ReactToCommentCommandResult>(command, cancellationToken));

    [HttpDelete()]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoveReaction([FromQuery] RemoveCommentCommand command, CancellationToken cancellationToken)
    {
        RemoveCommentCommandResult result = await _serviceBus.SendMessageAsync<RemoveCommentCommand, RemoveCommentCommandResult>(command, cancellationToken);
        return result.Failed() ? BadRequest(result) : NoContent();
    }
}