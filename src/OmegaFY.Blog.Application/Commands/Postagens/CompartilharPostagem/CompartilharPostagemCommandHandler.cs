using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Domain.Core.Authentication;
using OmegaFY.Blog.Domain.Core.Services;
using OmegaFY.Blog.Domain.Entities.Postagens;
using OmegaFY.Blog.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Application.Commands.Postagens.CompartilharPostagem
{

    public class CompartilharPostagemCommandHandler : PostagemCommandHandlerBase<CompartilharPostagemCommandHandler, CompartilharPostagemCommand, CompartilharPostagemCommandResult>
    {

        public CompartilharPostagemCommandHandler(IUserInformation user,
                                                  ILogger<CompartilharPostagemCommandHandler> logger,
                                                  IMapperServices mapper,
                                                  IPostagemRepository postagemRepository) : base(user, logger, mapper, postagemRepository) { }

        public override async Task<CompartilharPostagemCommandResult> Handle(CompartilharPostagemCommand request, CancellationToken cancellationToken)
        {
            Postagem postagem = await ObterPostagemCriticandoSeNaoExitirNoRepositorio(request.Id);

            Compartilhamento compartilhamento = new Compartilhamento(_user.CurrentRequestUserId, postagem.Id);

            postagem.Compartilhar(compartilhamento);

            return await Task.FromResult(new CompartilharPostagemCommandResult(compartilhamento.Id, postagem.Id, _user.CurrentRequestUserId));
        }

    }

}
