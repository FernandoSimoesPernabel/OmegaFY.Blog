using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Domain.Core.Authentication;
using OmegaFY.Blog.Domain.Core.Repositories;
using OmegaFY.Blog.Domain.Core.Services;
using OmegaFY.Blog.Domain.Entities.Postagens;
using OmegaFY.Blog.Domain.Repositories;
using OmegaFY.Blog.Domain.ValueObjects.Postagens;
using System.Threading;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Application.Commands.Postagens.PublicarPostagem
{

    public class PublicarPostagemCommandHandler : CommandHandlerMediatRBase<PublicarPostagemCommandHandler, PublicarPostagemCommand, PublicarPostagemCommandResult>
    {

        private readonly IPostagemRepository _postagemRepository;

        public PublicarPostagemCommandHandler(IUserInformation user,
                                              ILogger<PublicarPostagemCommandHandler> logger,
                                              IMapperServices mapper,
                                              IPostagemRepository postagemRepository)
            : base(user, logger,  mapper)
        {
            _postagemRepository = postagemRepository;
        }

        public override async Task<PublicarPostagemCommandResult> Handle(PublicarPostagemCommand request, CancellationToken cancellationToken)
        {
            Postagem postagem = new Postagem(_user.CurrentRequestUserId,
                                             new Cabecalho(request.Titulo, request.SubTitulo),
                                             request.ConteudoPostagem);

            await _postagemRepository.PublicarPostagem(postagem);

            return await Task.FromResult(_mapper.MapToObject<Postagem, PublicarPostagemCommandResult>(postagem));
        }

    }

}
