using Microsoft.AspNetCore.Mvc;
using OmegaFY.Blog.Application.Bus;
using OmegaFY.Blog.Application.Commands.Posts.PublishPost;
using OmegaFY.Blog.Application.Queries.Pagination;
using OmegaFY.Blog.Application.Queries.Posts.GetAllPosts;
using OmegaFY.Blog.Application.Queries.Posts.GetPost;
using OmegaFY.Blog.WebAPI.Controllers.Base;
using OmegaFY.Blog.WebAPI.Models.Commands;
using OmegaFY.Blog.WebAPI.Models.Queries;
using OmegaFY.Blog.WebAPI.Models.Responses;

namespace OmegaFY.Blog.WebAPI.Controllers;

[ApiVersion("1.0")]
public class PostsController : ApiControllerBase<PostsController>
{
    public PostsController(ILogger<PostsController> logger, IServiceBus serviceBus) : base(logger, serviceBus) { }

    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<PagedResult<GetAllPostsQueryResult>>), 200)]
    public async Task<IActionResult> GetAllPosts([FromQuery] GetAllPostsInputModel inputModel, CancellationToken cancellationToken)
    {
        GetAllPostsQuery query = inputModel.ToCommand();

        PagedResult<GetAllPostsQueryResult> result =
                        await _serviceBus.SendMessageAsync<GetAllPostsQuery, PagedResult<GetAllPostsQueryResult>>(query, cancellationToken);

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ApiResponse<GetPostQueryResult>), 200)]
    [ProducesResponseType(typeof(ApiResponse), 404)]
    public async Task<IActionResult> GetPost([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        GetPostQuery query = new GetPostQuery(id);

        GetPostQueryResult result =
                        await _serviceBus.SendMessageAsync<GetPostQuery, GetPostQueryResult>(query, cancellationToken);

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<PublishPostCommandResult>), 201)]
    [ProducesResponseType(typeof(ApiResponse), 400)]
    public async Task<IActionResult> PublicarPostagem(PublishPostInputModel inputModel, CancellationToken cancellationToken)
    {
        PublishPostCommand command = inputModel.ToCommand();

        PublishPostCommandResult result =
                        await _serviceBus.SendMessageAsync<PublishPostCommand, PublishPostCommandResult>(command, cancellationToken);

        return CreatedAtAction(nameof(GetPost), new { id = result.Id }, result);
    }
}