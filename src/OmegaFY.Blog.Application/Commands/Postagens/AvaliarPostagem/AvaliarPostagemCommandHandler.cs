using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Domain.Core.Authentication;
using OmegaFY.Blog.Domain.Core.Services;
using OmegaFY.Blog.Domain.Entities.Postagens;
using OmegaFY.Blog.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Application.Commands.Postagens.AvaliarPostagem
{

    public class AvaliarPostagemCommandHandler : PostagemCommandHandlerBase<AvaliarPostagemCommandHandler, AvaliarPostagemCommand, AvaliarPostagemCommandResult>
    {

        public AvaliarPostagemCommandHandler(IUserInformation user,
                                             ILogger<AvaliarPostagemCommandHandler> logger,
                                             IMapperServices mapper,
                                             IPostagemRepository postagemRepository) : base(user, logger, mapper, postagemRepository) { }

        public async override Task<AvaliarPostagemCommandResult> Handle(AvaliarPostagemCommand request, CancellationToken cancellationToken)
        {
            Postagem postagem = await ObterPostagemCriticandoSeNaoExitirNoRepositorio(request.Id);

            Avaliacao avaliacao = new Avaliacao(_user.CurrentRequestUserId, postagem.Id, request.Estrelas);

            postagem.Avaliar(avaliacao);

            return await Task.FromResult(new AvaliarPostagemCommandResult(avaliacao.Id, postagem.Id, _user.CurrentRequestUserId));
        }

    }

}
