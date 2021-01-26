using MediatR;
using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Domain.Core.Authentication;
using OmegaFY.Blog.Domain.Core.Services;
using OmegaFY.Blog.Domain.Entities.Postagens;
using OmegaFY.Blog.Domain.Exceptions;
using OmegaFY.Blog.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Application.Commands.Postagens
{

    public abstract class PostagemCommandHandlerBase<THandler, TCommand, TResult> : CommandHandlerMediatRBase<THandler, TCommand, TResult> where TCommand : IRequest<TResult>
    {

        protected readonly IPostagemRepository _postagemRepository;

        public PostagemCommandHandlerBase(IUserInformation user,
                                          ILogger<THandler> logger,
                                          IMapperServices mapper,
                                          IPostagemRepository postagemRepository) : base(user, logger, mapper)
        {
            _postagemRepository = postagemRepository;
        }

        protected async Task<Postagem> ObterPostagemCriticandoSeNaoExitirNoRepositorio(Guid id)
        {
            Postagem postagem = await _postagemRepository.PesquisarPostagemPeloId(id);

            if (postagem == null)
                throw new NotFoundException("Não foi possível encontrar a postagem informada em nossa base de dados.");

            return postagem;
        }

    }

}
