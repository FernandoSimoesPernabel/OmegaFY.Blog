using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Postagens.AvaliarPostagem;
using OmegaFY.Blog.Application.Commands.Postagens.ComentarComentario;
using OmegaFY.Blog.Application.Commands.Postagens.ComentarPostagem;
using OmegaFY.Blog.Application.Commands.Postagens.CompartilharPostagem;
using OmegaFY.Blog.Application.Commands.Postagens.DescompartilharPostagem;
using OmegaFY.Blog.Application.Commands.Postagens.DesocultarPostagem;
using OmegaFY.Blog.Application.Commands.Postagens.EditarComentario;
using OmegaFY.Blog.Application.Commands.Postagens.EditarDadosPostagem;
using OmegaFY.Blog.Application.Commands.Postagens.EditarSubComentario;
using OmegaFY.Blog.Application.Commands.Postagens.ExcluirComentario;
using OmegaFY.Blog.Application.Commands.Postagens.ExcluirPostagem;
using OmegaFY.Blog.Application.Commands.Postagens.ExcluirSubComentario;
using OmegaFY.Blog.Application.Commands.Postagens.OcultarPostagem;
using OmegaFY.Blog.Application.Commands.Postagens.PublicarPostagem;
using OmegaFY.Blog.Application.Commands.Postagens.ReagirComentario;
using OmegaFY.Blog.Application.Commands.Postagens.ReagirSubComentario;
using OmegaFY.Blog.Application.Commands.Postagens.RemoverAvaliacaoPostagem;
using OmegaFY.Blog.Application.Commands.Postagens.RemoverReacaoComentario;
using OmegaFY.Blog.Application.Commands.Postagens.RemoverReacaoSubComentario;
using OmegaFY.Blog.Application.Queries.Postagens.ListarPostagensRecentes;
using OmegaFY.Blog.Application.Queries.Postagens.ObterPostagem;
using OmegaFY.Blog.Domain.Core.Services;
using OmegaFY.Blog.WebAPI.Controllers.Base;
using OmegaFY.Blog.WebAPI.Models.CommandsViewModels;
using OmegaFY.Blog.WebAPI.Models.QueriesViewModels;
using OmegaFY.Blog.WebAPI.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace OmegaFY.Blog.WebAPI.Controllers
{
    public class PostagensController : ApiControllerBase<PostagensController>
    {

        public PostagensController(ILogger<PostagensController> logger,
                                   IServiceBus serviceBus,
                                   IMapperServices mapper) : base(logger, serviceBus, mapper) { }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(ApiResponse<ObterPostagemQueryResult>), 200)]
        [ProducesResponseType(typeof(ApiResponse), 404)]
        public async Task<IActionResult> ObterPostagemAsync([FromQuery] ObterPostagemViewModel viewModel, CancellationToken cancellationToken)
        {
            ObterPostagemQuery query = _mapper.MapToObject<ObterPostagemViewModel, ObterPostagemQuery>(viewModel);

            ObterPostagemQueryResult result =
                            await _serviceBus.SendMessageAsync<ObterPostagemQuery, ObterPostagemQueryResult>(query, cancellationToken);

            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<ListarPostagensRecentesQuery>), 200)]
        public async Task<IActionResult> ListarPostagensRecentesAsync([FromQuery] ListarPostagensRecentesViewModel viewModel, CancellationToken cancellationToken)
        {
            ListarPostagensRecentesQuery query = _mapper.MapToObject<ListarPostagensRecentesViewModel, ListarPostagensRecentesQuery>(viewModel);

            ListarPostagensRecentesQueryResult result =
                            await _serviceBus.SendMessageAsync<ListarPostagensRecentesQuery, ListarPostagensRecentesQueryResult>(query, cancellationToken);

            return Ok(result);
        }

        [HttpGet("listar-por-usuario")]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 404)]
        public async Task<IActionResult> ListarPostagensPorUsuarioAsync(ListarPostagensPorUsuarioViewModel viewModel, CancellationToken cancellationToken)
        {
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<PublicarPostagemCommandResult>), 201)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<IActionResult> PublicarPostagemAsync(PublicarPostagemViewModel viewModel, CancellationToken cancellationToken)
        {
            PublicarPostagemCommand command = _mapper.MapToObject<PublicarPostagemViewModel, PublicarPostagemCommand>(viewModel);

            PublicarPostagemCommandResult result =
                            await _serviceBus.SendMessageAsync<PublicarPostagemCommand, PublicarPostagemCommandResult>(command, cancellationToken);

            return CreatedAtAction(nameof(ObterPostagemAsync), new { id = result.Id }, result);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(ApiResponse<EditarDadosPostagemCommandResult>), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<IActionResult> EditarDadosPostagemAsync(EditarDadosPostagemViewModel viewModel, CancellationToken cancellationToken)
        {
            EditarDadosPostagemCommand command = _mapper.MapToObject<EditarDadosPostagemViewModel, EditarDadosPostagemCommand>(viewModel);

            EditarDadosPostagemCommandResult result =
                await _serviceBus.SendMessageAsync<EditarDadosPostagemCommand, EditarDadosPostagemCommandResult>(command, cancellationToken);

            return Ok(result);
        }

        [HttpPatch("{id:guid}/ocultar")]
        [ProducesResponseType(typeof(ApiResponse<OcultarPostagemCommandResult>), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<IActionResult> OcultarPostagemAsync(OcultarPostagemViewModel viewModel, CancellationToken cancellationToken)
        {
            OcultarPostagemCommand command = _mapper.MapToObject<OcultarPostagemViewModel, OcultarPostagemCommand>(viewModel);

            OcultarPostagemCommandResult result =
                await _serviceBus.SendMessageAsync<OcultarPostagemCommand, OcultarPostagemCommandResult>(command, cancellationToken);

            return Ok();
        }

        [HttpPatch("{id:guid}/desocultar")]
        [ProducesResponseType(typeof(ApiResponse<DesocultarPostagemCommandResult>), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<IActionResult> DesocultarPostagemAsync(DesocultarPostagemViewModel viewModel, CancellationToken cancellationToken)
        {
            DesocultarPostagemCommand command = _mapper.MapToObject<DesocultarPostagemViewModel, DesocultarPostagemCommand>(viewModel);

            DesocultarPostagemCommandResult result =
                await _serviceBus.SendMessageAsync<DesocultarPostagemCommand, DesocultarPostagemCommandResult>(command, cancellationToken);

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(ApiResponse<ExcluirPostagemCommandResult>), 204)]
        [ProducesResponseType(typeof(ApiResponse), 404)]
        public async Task<IActionResult> ExcluirPostagemAsync(ExcluirPostagemViewModel viewModel, CancellationToken cancellationToken)
        {
            ExcluirPostagemCommand command = _mapper.MapToObject<ExcluirPostagemViewModel, ExcluirPostagemCommand>(viewModel);

            ExcluirPostagemCommandResult result =
                await _serviceBus.SendMessageAsync<ExcluirPostagemCommand, ExcluirPostagemCommandResult>(command, cancellationToken);

            return NoContent();
        }

        [HttpGet("{id:guid}/comentarios/{idComentario:guid}")]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 404)]
        public async Task<IActionResult> ObterComentarioAsync(ObterComentarioViewModel viewModel, CancellationToken cancellationToken)
        {
            return Ok();
        }

        [HttpGet("{id:guid}/comentarios")]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 404)]
        public async Task<IActionResult> ListarComentariosPostagemAsync(ListarComentariosPostagemViewModel viewModel, CancellationToken cancellationToken)
        {
            return Ok();
        }

        [HttpPost("{id:guid}/comentarios")]
        [ProducesResponseType(typeof(ApiResponse<ComentarPostagemCommandResult>), 201)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        [ProducesResponseType(typeof(ApiResponse), 404)]
        public async Task<IActionResult> ComentarPostagemAsync(ComentarPostagemViewModel viewModel, CancellationToken cancellationToken)
        {
            ComentarPostagemCommand command = _mapper.MapToObject<ComentarPostagemViewModel, ComentarPostagemCommand>(viewModel);

            ComentarPostagemCommandResult result =
                await _serviceBus.SendMessageAsync<ComentarPostagemCommand, ComentarPostagemCommandResult>(command, cancellationToken);

            return CreatedAtAction(nameof(ObterComentarioAsync), null, null);
        }

        [HttpPut("{id:guid}/comentarios/{comentarioId:guid}")]
        [ProducesResponseType(typeof(ApiResponse<EditarComentarioCommandResult>), 200)]
        [ProducesResponseType(typeof(ApiResponse), 404)]
        public async Task<IActionResult> EditarComentarioAsync(EditarComentarioPostagemViewModel viewModel, CancellationToken cancellationToken)
        {
            EditarComentarioCommand command = _mapper.MapToObject<EditarComentarioPostagemViewModel, EditarComentarioCommand>(viewModel);

            EditarComentarioCommandResult result =
                await _serviceBus.SendMessageAsync<EditarComentarioCommand, EditarComentarioCommandResult>(command, cancellationToken);

            return Ok();
        }

        [HttpDelete("{id:guid}/comentarios/{comentarioId:guid}")]
        [ProducesResponseType(typeof(ApiResponse<ExcluirComentarioCommandResult>), 204)]
        [ProducesResponseType(typeof(ApiResponse), 404)]
        public async Task<IActionResult> ExcluirComentarioAsync(ExcluirComentarioViewModel viewModel, CancellationToken cancellationToken)
        {
            ExcluirComentarioCommand command = _mapper.MapToObject<ExcluirComentarioViewModel, ExcluirComentarioCommand>(viewModel);

            ExcluirComentarioCommandResult result =
                await _serviceBus.SendMessageAsync<ExcluirComentarioCommand, ExcluirComentarioCommandResult>(command, cancellationToken);

            return NoContent();
        }

        [HttpGet("{id:guid}/comentarios/{comentarioId:guid}/reacoes/{reacaoId:guid}")]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 404)]
        public async Task<IActionResult> ObterReacaoComentarioAsync(ObterReacaoComentarioViewModel viewModel, CancellationToken cancellationToken)
        {
            return Ok();
        }

        [HttpGet("{id:guid}/comentarios/{comentarioId:guid}/reacoes")]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 404)]
        public async Task<IActionResult> ListarReacoesComentarioPostagemAsync(ListarReacoesComentarioPostagemViewModel viewModel, CancellationToken cancellationToken)
        {
            return Ok();
        }

        [HttpPost("{id:guid}/comentarios/{comentarioId:guid}/reacoes")]
        [ProducesResponseType(typeof(ApiResponse<ReagirComentarioCommandResult>), 201)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        [ProducesResponseType(typeof(ApiResponse), 404)]
        public async Task<IActionResult> ReagirComentarioAsync(ReagirComentarioViewModel viewModel, CancellationToken cancellationToken)
        {
            ReagirComentarioCommand command = _mapper.MapToObject<ReagirComentarioViewModel, ReagirComentarioCommand>(viewModel);

            ReagirComentarioCommandResult result =
                await _serviceBus.SendMessageAsync<ReagirComentarioCommand, ReagirComentarioCommandResult>(command, cancellationToken);

            return CreatedAtAction(nameof(ObterReacaoComentarioAsync), null, null);
        }

        [HttpDelete("{id:guid}/comentarios/{comentarioId:guid}/reacoes/{reacaoId:guid}")]
        [ProducesResponseType(typeof(ApiResponse<RemoverReacaoComentarioCommandResult>), 204)]
        [ProducesResponseType(typeof(ApiResponse), 404)]
        public async Task<IActionResult> RemoverReacaoComentarioAsync(RemoverReacaoComentarioViewModel viewModel, CancellationToken cancellationToken)
        {
            RemoverReacaoComentarioCommand command = _mapper.MapToObject<RemoverReacaoComentarioViewModel, RemoverReacaoComentarioCommand>(viewModel);

            RemoverReacaoComentarioCommandResult result =
                await _serviceBus.SendMessageAsync<RemoverReacaoComentarioCommand, RemoverReacaoComentarioCommandResult>(command, cancellationToken);

            return NoContent();
        }

        [HttpGet("{id:guid}/comentarios/{comentarioId:guid}/subcomentarios/{subComentarioId:guid}")]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 404)]
        public async Task<IActionResult> ObterSubComentarioAsync(ObterSubComentarioViewModel viewModel, CancellationToken cancellationToken)
        {
            return Ok();
        }

        [HttpGet("{id:guid}/comentarios/{comentarioId:guid}/subcomentarios")]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 404)]
        public async Task<IActionResult> ListarSubComentariosPostagemAsync(ListarSubComentariosPostagemViewModel viewModel, CancellationToken cancellationToken)
        {
            return Ok();
        }

        [HttpPost("{id:guid}/comentarios/{comentarioId:guid}/subcomentarios")]
        [ProducesResponseType(typeof(ApiResponse<ComentarComentarioCommandResult>), 201)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        [ProducesResponseType(typeof(ApiResponse), 404)]
        public async Task<IActionResult> ComentarComentarioAsync(ComentarComentarioViewModel viewModel, CancellationToken cancellationToken)
        {
            ComentarComentarioCommand command = _mapper.MapToObject<ComentarComentarioViewModel, ComentarComentarioCommand>(viewModel);

            ComentarComentarioCommandResult result =
                await _serviceBus.SendMessageAsync<ComentarComentarioCommand, ComentarComentarioCommandResult>(command, cancellationToken);

            return CreatedAtAction(nameof(ObterSubComentarioAsync), null, null);
        }

        [HttpPut("{id:guid}/comentarios/{comentarioId:guid}/subcomentarios/{subComentarioId:guid}")]
        [ProducesResponseType(typeof(ApiResponse<EditarSubComentarioCommandResult>), 200)]
        [ProducesResponseType(typeof(ApiResponse), 404)]
        public async Task<IActionResult> EditarSubComentarioAsync(EditarSubComentarioPostagemViewModel viewModel, CancellationToken cancellationToken)
        {
            EditarSubComentarioCommand command = _mapper.MapToObject<EditarSubComentarioPostagemViewModel, EditarSubComentarioCommand>(viewModel);

            EditarSubComentarioCommandResult result =
                await _serviceBus.SendMessageAsync<EditarSubComentarioCommand, EditarSubComentarioCommandResult>(command, cancellationToken);

            return Ok();
        }

        [HttpDelete("{id:guid}/comentarios/{comentarioId:guid}/subcomentarios/{subComentarioId:guid}")]
        [ProducesResponseType(typeof(ApiResponse<ExcluirSubComentarioCommandResult>), 204)]
        [ProducesResponseType(typeof(ApiResponse), 404)]
        public async Task<IActionResult> ExcluirSubComentarioAsync(ExcluirSubComentarioViewModel viewModel, CancellationToken cancellationToken)
        {
            ExcluirSubComentarioCommand command = _mapper.MapToObject<ExcluirSubComentarioViewModel, ExcluirSubComentarioCommand>(viewModel);

            ExcluirSubComentarioCommandResult result =
                await _serviceBus.SendMessageAsync<ExcluirSubComentarioCommand, ExcluirSubComentarioCommandResult>(command, cancellationToken);

            return NoContent();
        }

        [HttpGet("{id:guid}/comentarios/{comentarioId:guid}/subcomentarios/{subComentarioId:guid}/reacoes/{reacaoId:guid}")]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 404)]
        public async Task<IActionResult> ObterReacaoSubComentarioAsync(ObterReacaoSubComentarioViewModel viewModel, CancellationToken cancellationToken)
        {
            return Ok();
        }

        [HttpGet("{id:guid}/comentarios/{comentarioId:guid}/subcomentarios/{subComentarioId:guid}/reacoes")]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 404)]
        public async Task<IActionResult> ListarReacoesSubComentarioPostagemAsync(ListarReacoesSubComentarioPostagemViewModel viewModel, CancellationToken cancellationToken)
        {
            return Ok();
        }

        [HttpPost("{id:guid}/comentarios/{comentarioId:guid}/subcomentarios/{subComentarioId:guid}/reacoes")]
        [ProducesResponseType(typeof(ApiResponse<ReagirSubComentarioCommandResult>), 201)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        [ProducesResponseType(typeof(ApiResponse), 404)]
        public async Task<IActionResult> ReagirSubComentarioAsync(ReagirSubComentarioViewModel viewModel, CancellationToken cancellationToken)
        {
            ReagirSubComentarioCommand command = _mapper.MapToObject<ReagirSubComentarioViewModel, ReagirSubComentarioCommand>(viewModel);

            ReagirSubComentarioCommandResult result =
                await _serviceBus.SendMessageAsync<ReagirSubComentarioCommand, ReagirSubComentarioCommandResult>(command, cancellationToken);

            return CreatedAtAction(nameof(ObterReacaoSubComentarioAsync), null, null);
        }

        [HttpDelete("{id:guid}/comentarios/{comentarioId:guid}/subcomentarios/{subComentarioId:guid}/reacoes/{reacaoId:guid}")]
        [ProducesResponseType(typeof(ApiResponse<RemoverReacaoSubComentarioCommandResult>), 204)]
        [ProducesResponseType(typeof(ApiResponse), 404)]
        public async Task<IActionResult> RemoverReacaoSubComentarioAsync(RemoverReacaoSubComentarioViewModel viewModel, CancellationToken cancellationToken)
        {
            RemoverReacaoSubComentarioCommand command = _mapper.MapToObject<RemoverReacaoSubComentarioViewModel, RemoverReacaoSubComentarioCommand>(viewModel);

            RemoverReacaoSubComentarioCommandResult result =
                await _serviceBus.SendMessageAsync<RemoverReacaoSubComentarioCommand, RemoverReacaoSubComentarioCommandResult>(command, cancellationToken);

            return NoContent();
        }

        [HttpGet("{id:guid}/compartilhamentos/{compartilhamentoId:guid}")]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 404)]
        public async Task<IActionResult> ObterCompartilhamentoAsync(ObterCompartilhamentoViewModel viewModel, CancellationToken cancellationToken)
        {
            return Ok();
        }

        [HttpGet("{id:guid}/compartilhamentos")]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 404)]
        public async Task<IActionResult> ListarCompartilhamentosPostagemAsync(ListarCompartilhamentosPostagemViewModel viewModel, CancellationToken cancellationToken)
        {
            return Ok();
        }

        [HttpPost("{id:guid}/compartilhamentos")]
        [ProducesResponseType(typeof(ApiResponse<CompartilharPostagemCommandResult>), 201)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        [ProducesResponseType(typeof(ApiResponse), 404)]
        public async Task<IActionResult> CompartilharPostagemAsync([FromQuery] CompartilharPostagemViewModel viewModel, CancellationToken cancellationToken)
        {
            CompartilharPostagemCommand command = _mapper.MapToObject<CompartilharPostagemViewModel, CompartilharPostagemCommand>(viewModel);

            CompartilharPostagemCommandResult result =
                await _serviceBus.SendMessageAsync<CompartilharPostagemCommand, CompartilharPostagemCommandResult>(command, cancellationToken);

            return CreatedAtAction(nameof(ObterCompartilhamentoAsync), null, null);
        }

        [HttpDelete("{id:guid}/compartilhamentos/{compartilhamentoId:guid}")]
        [ProducesResponseType(typeof(ApiResponse<DescompartilharPostagemCommandResult>), 204)]
        [ProducesResponseType(typeof(ApiResponse), 404)]
        public async Task<IActionResult> DescompartilharPostagemAsync(DescompartilharPostagemViewModel viewModel, CancellationToken cancellationToken)
        {
            DescompartilharPostagemCommand command = _mapper.MapToObject<DescompartilharPostagemViewModel, DescompartilharPostagemCommand>(viewModel);

            DescompartilharPostagemCommandResult result =
                await _serviceBus.SendMessageAsync<DescompartilharPostagemCommand, DescompartilharPostagemCommandResult>(command, cancellationToken);

            return NoContent();
        }

        [HttpGet("{id:guid}/avaliacoes/{avalicaoId:guid}")]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 404)]
        public async Task<IActionResult> ObterAvaliacaoAsync(ObterAvaliacaoViewModel viewModel, CancellationToken cancellationToken)
        {
            return Ok();
        }

        [HttpGet("{id:guid}/avaliacoes")]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 404)]
        public async Task<IActionResult> ListarAvaliacoesPostagemAsync(ListarAvaliacoesPostagemViewModel viewModel, CancellationToken cancellationToken)
        {
            return Ok();
        }

        [HttpPost("{id:guid}/avaliacoes")]
        [ProducesResponseType(typeof(ApiResponse<AvaliarPostagemCommandResult>), 201)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        [ProducesResponseType(typeof(ApiResponse), 404)]
        public async Task<IActionResult> AvaliarPostagemAsync(AvaliarPostagemViewModel viewModel, CancellationToken cancellationToken)
        {
            AvaliarPostagemCommand command = _mapper.MapToObject<AvaliarPostagemViewModel, AvaliarPostagemCommand>(viewModel);

            AvaliarPostagemCommandResult result =
                await _serviceBus.SendMessageAsync<AvaliarPostagemCommand, AvaliarPostagemCommandResult>(command, cancellationToken);

            return CreatedAtAction(nameof(ObterAvaliacaoAsync), null, null);
        }

        [HttpDelete("{id:guid}/avaliacoes/{avalicaoId:guid}")]
        [ProducesResponseType(typeof(ApiResponse<RemoverAvaliacaoPostagemCommandResult>), 204)]
        [ProducesResponseType(typeof(ApiResponse), 404)]
        public async Task<IActionResult> RemoverAvaliacaoPostagemAsync(RemoverAvaliacaoPostagemViewModel viewModel, CancellationToken cancellationToken)
        {
            RemoverAvaliacaoPostagemCommand command = _mapper.MapToObject<RemoverAvaliacaoPostagemViewModel, RemoverAvaliacaoPostagemCommand>(viewModel);

            RemoverAvaliacaoPostagemCommandResult result =
                await _serviceBus.SendMessageAsync<RemoverAvaliacaoPostagemCommand, RemoverAvaliacaoPostagemCommandResult>(command, cancellationToken);

            return NoContent();
        }

    }
}
