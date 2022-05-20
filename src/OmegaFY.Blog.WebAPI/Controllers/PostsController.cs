using Microsoft.AspNetCore.Mvc;
using OmegaFY.Blog.Application.Commands.PublishPost;
using OmegaFY.Blog.Application.Queries.Posts.GetPost;
using OmegaFY.Blog.Domain.Bus;
using OmegaFY.Blog.Domain.QueryProviders.Posts.QueryResults;
using OmegaFY.Blog.WebAPI.Controllers.Base;
using OmegaFY.Blog.WebAPI.Models.Commands;
using OmegaFY.Blog.WebAPI.Models.Responses;

namespace OmegaFY.Blog.WebAPI.Controllers;

[ApiVersion("1.0")]
public class PostsController : ApiControllerBase<PostsController>
{
    public PostsController(ILogger<PostsController> logger, IServiceBus serviceBus) : base(logger, serviceBus) { }

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
    public async Task<IActionResult> PublicarPostagemAsync(PublishPostViewModel viewModel, CancellationToken cancellationToken)
    {
        PublishPostCommand command = viewModel.ToCommand();

        PublishPostCommandResult result =
                        await _serviceBus.SendMessageAsync<PublishPostCommand, PublishPostCommandResult>(command, cancellationToken);

        return CreatedAtAction(nameof(GetPost), new { id = result.Id }, result);
    }
}