using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Domain.Core.Authentication;
using OmegaFY.Blog.Domain.Core.Services;
using OmegaFY.Blog.Domain.Entities.Comentarios;
using OmegaFY.Blog.Domain.Entities.Postagens;
using OmegaFY.Blog.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Application.Commands.Postagens.ComentarPostagem
{

    public class ComentarPostagemCommandHandler : PostagemCommandHandlerBase<ComentarPostagemCommandHandler, ComentarPostagemCommand, ComentarPostagemCommandResult>
    {

        public ComentarPostagemCommandHandler(IUserInformation user,
                                              ILogger<ComentarPostagemCommandHandler> logger,
                                              IMapperServices mapper,
                                              IPostagemRepository postagemRepository) : base(user, logger, mapper, postagemRepository) { }

        public override async Task<ComentarPostagemCommandResult> Handle(ComentarPostagemCommand request, CancellationToken cancellationToken)
        {
            Postagem postagem = await ObterPostagemCriticandoSeNaoExitirNoRepositorio(request.Id);

            Comentario comentario = new Comentario(_user.CurrentRequestUserId, postagem.Id, request.Comentario);

            postagem.Comentar(comentario);

            return await Task.FromResult(new ComentarPostagemCommandResult(comentario.Id, postagem.Id, _user.CurrentRequestUserId));
        }

    }

}
