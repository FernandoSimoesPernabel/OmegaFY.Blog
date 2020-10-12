using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Postagens;
using OmegaFY.Blog.Domain.Core.Services;
using OmegaFY.Blog.WebAPI.Controllers.Base;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OmegaFY.Blog.WebAPI.Controllers
{
    public class PostagensController : ApiControllerBase<PostagensController>
    {

        public PostagensController(ILogger<PostagensController> logger, IServiceBus serviceBus) : base(logger, serviceBus)
        {
        }

        [HttpGet()]
        public async Task<IActionResult> List(CancellationToken cancellationToken)
        {
            var c = new PublicarPostagemCommand() { ConteudoPostagem = "Conteudo", Titulo = "Titulo", SubTitulo = "SubTitulo" };

            return Ok(await _serviceBus
                .SendMessageAsync<PublicarPostagemCommand, PublicarPostagemCommandResult>(c, cancellationToken));
        }

        [HttpGet("id:guid")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post(PublicarPostagemCommand publicarPostagemCommand)
        {
            return Ok();
        }

        [HttpPut("id:guid")]
        public async Task<IActionResult> Put(Guid guid, object editarPostagemCommand)
        {
            return Ok();
        }

        [HttpPatch("id:guid")]
        public async Task<IActionResult> Patch(Guid id, object editarPostagemCommand)
        {
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return NoContent();
        }

    }
}
