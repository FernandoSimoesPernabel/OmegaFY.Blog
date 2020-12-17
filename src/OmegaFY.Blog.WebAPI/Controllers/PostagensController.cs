using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Postagens.PublicarPostagem;
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
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> List(CancellationToken cancellationToken)
        {
            var c = new PublicarPostagemCommand() { ConteudoPostagem = "Conteudo", Titulo = "Titulo", SubTitulo = "SubTitulo" };

            PublicarPostagemCommandResult result =
                await _serviceBus.SendMessageAsync<PublicarPostagemCommand, PublicarPostagemCommandResult>(c, cancellationToken);

            return CreatedAtAction(nameof(ObterAsync), new { id = result.Id }, result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> ObterAsync([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            return Ok();
        }

        //[HttpGet("")]
        //public async Task<IActionResult> ListarPostagensRecentesAsync([FromQuery] PagedRequest pagedRequest, 
        //                                                              CancellationToken cancellationToken)
        //{
        //    return Ok();
        //}

        //[HttpGet("/listar-por-usuario")]
        //public async Task<IActionResult> ListarPostagensRecentesAsync([FromRoute]Guid usuarioId,
        //                                                              [FromQuery] PagedRequest pagedRequest,
        //                                                              CancellationToken cancellationToken)
        //{
        //    return Ok();
        //}

        //[HttpPost]
        //public async Task<IActionResult> PublicarPostagemAsync(PublicarPostagemCommand command, CancellationToken cancellationToken)
        //{

        //}

        // [HttpPut("{id:guid}")]
        // public async Task<IActionResult> EditarDadosPostagemAsync([FromRoute]Guid id, 
        //                                                           EditarDadosPostagemCommand command, 
        //                                                           CancellationToken cancellationToken)
        // {
        //     return Ok();
        // }

        //[HttpPatch("{id:guid}/ocultar")]
        //public async Task<IActionResult> OcultarPostagemAsync([FromRoute]Guid id, 
        //                                                      OcultarPostagemCommand command, 
        //                                                      CancellationToken cancellationToken)
        //{

        //}

        // [HttpPatch("{id:guid}/desocultar")]
        // public async Task<IActionResult> DesocultarPostagemAsync([FromRoute]Guid id,
        //                                                          DesocultarPostagemCommand command, 
        //                                                          CancellationToken cancellationToken)
        // {

        // }

        //[HttpDelete("{id:guid}")]
        //public async Task<IActionResult> ExcluirPostagemAsync(ExcluirPostagemCommand command, CancellationToken cancellationToken)
        //{

        //}

        //[HttpPost("{id:guid}/comentarios")]
        //public async Task<IActionResult> ComentarPostagemAsync(ComentarPostagemCommand command, CancellationToken cancellationToken)
        //{

        //}

        //[HttpPut("{id:guid}/comentarios/{comentarioId:guid}")]
        //public async Task<IActionResult> EditarComentarioAsync(EditarComentarioPostagemCommand command, CancellationToken cancellationToken)
        //{

        //}

        //[HttpDelete("{id:guid}/comentarios/{comentarioId:guid}")]
        //public async Task<IActionResult> ExcluirComentarioAsync(ExcluirComentarioCommand command, CancellationToken cancellationToken)
        //{

        //}

        //[HttpPost("{id:guid}/comentarios/{comentarioId:guid}/subcomentarios")]
        //public async Task<IActionResult> ComentarComentarioAsync(ComentarComentarioCommand command, CancellationToken cancellationToken)
        //{

        //}

        //[HttpPut("{id:guid}/comentarios/{comentarioId:guid}/subcomentarios/{subcomentarioId:guid}")]
        //public async Task<IActionResult> EditarSubComentarioAsync(EditarSubComentarioPostagemCommand command, CancellationToken cancellationToken)
        //{

        //}

        //[HttpDelete("{id:guid}/comentarios/{comentarioId:guid}/subcomentarios/{subcomentarioId:guid}")]
        //public async Task<IActionResult> ExcluirSubComentarioAsync(ExcluirSubComentarioCommand command, CancellationToken cancellationToken)
        //{

        //}

        //[HttpPost("{id:guid}/compartilhamentos")]
        //public async Task<IActionResult> CompartilharPostagemAsync(CompartilharPostagemCommand command, CancellationToken cancellationToken)
        //{

        //}

        //[HttpDelete("{id:guid}/compartilhamentos/{compartilhamentoId:guid}")]
        //public async Task<IActionResult> DescompartilharPostagemAsync(DescompartilharPostagemCommand command, CancellationToken cancellationToken)
        //{

        //}

        //[HttpPost("{id:guid}/avaliacoes")]
        //public async Task<IActionResult> AvaliarPostagemAsync(AvaliarPostagemCommand command, CancellationToken cancellationToken)
        //{

        //}

        //[HttpDelete("{id:guid}/avaliacoes/{avalicaoId:guid}")]
        //public async Task<IActionResult> RemoverAvaliacaoPostagemAsync(RemoverAvaliacaoPostagemCommand command, CancellationToken cancellationToken)
        //{

        //}

        //[HttpPost("{id:guid}/comentarios/{comentarioId:guid}/reacoes")]
        //public async Task<IActionResult> ReagirComentarioAsync(ReagirComentarioPostagemCommand command, CancellationToken cancellationToken)
        //{

        //}

        //[HttpDelete("{id:guid}/comentarios/{comentarioId:guid}/reacoes/{reacaoId:guid}")]
        //public async Task<IActionResult> RemoverReacaoComentarioAsync(RemoverReacaoComentarioPostagemCommand command, CancellationToken cancellationToken)
        //{

        //}

        //[HttpPost("{id:guid}/comentarios/{comentarioId:guid}/subcomentarios/{subcomentarioId:guid}/reacoes)]
        //public async Task<IActionResult> ReagirSubComentarioAsync(ReagirSubComentarioPostagemCommand command, CancellationToken cancellationToken)
        //{

        //}

        //[HttpDelete("{id:guid}/comentarios/{comentarioId:guid}/subcomentarios/{subcomentarioId:guid}/reacoes/{reacaoId:guid}")]
        //public async Task<IActionResult> RemoverReacaoSubComentarioAsync(RemoverReacaoSubComentarioPostagemCommand command, CancellationToken cancellationToken)
        //{

        //}

    }
}
