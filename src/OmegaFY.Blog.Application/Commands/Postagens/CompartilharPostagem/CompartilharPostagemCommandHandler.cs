using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Application.Commands.Postagens.PublicarPostagem;
using OmegaFY.Blog.Domain.Core.Authentication;
using OmegaFY.Blog.Domain.Core.Services;
using OmegaFY.Blog.Domain.Entities.Postagens;
using OmegaFY.Blog.Domain.Exceptions;
using OmegaFY.Blog.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Application.Commands.Postagens.CompartilharPostagem
{

    public class CompartilharPostagemCommandHandler : CommandHandlerMediatRBase<CompartilharPostagemCommandHandler, CompartilharPostagemCommand, CompartilharPostagemCommandResult>
    {

        private readonly IPostagemRepository _postagemRepository;

        public CompartilharPostagemCommandHandler(IUserInformation user,
                                                  ILogger<CompartilharPostagemCommandHandler> logger,
                                                  IMapperServices mapper,
                                                  IPostagemRepository postagemRepository)
            : base(user, logger, mapper)
        {
            _postagemRepository = postagemRepository;
        }

        public override async Task<CompartilharPostagemCommandResult> Handle(CompartilharPostagemCommand request, CancellationToken cancellationToken)
        {
            Postagem postagem = await _postagemRepository.PesquisarPostagemPeloId(request.Id);

            if (postagem == null)
                throw new NotFoundException("Não foi possível encontrar a postagem informada em nossa base de dados.");

            Compartilhamento compartilhamento = new Compartilhamento(_user.CurrentRequestUserId, postagem.Id);

            postagem.Compartilhar(compartilhamento);

            _postagemRepository.AtualizarDadosPostagem(postagem);

            return await Task.FromResult(new CompartilharPostagemCommandResult(compartilhamento.Id, postagem.Id, _user.CurrentRequestUserId));
        }

    }

}
