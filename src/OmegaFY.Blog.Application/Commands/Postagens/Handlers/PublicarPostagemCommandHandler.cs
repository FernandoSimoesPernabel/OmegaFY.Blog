﻿using MediatR;
using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Domain.Core.Authentication;
using OmegaFY.Blog.Domain.Core.Repositories;
using OmegaFY.Blog.Domain.Entities.Postagens;
using OmegaFY.Blog.Domain.Repositories;
using OmegaFY.Blog.Domain.ValueObjects.Postagens;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Application.Commands.Postagens.Handlers
{

    public class PublicarPostagemCommandHandler : CommandHandlerBase<PublicarPostagemCommandHandler>, IRequestHandler<PublicarPostagemCommand, PublicarPostagemCommandResult>
    {

        private readonly IPostagemRepository _postagemRepository;

        public PublicarPostagemCommandHandler(IPostagemRepository postagemRepository)
        {
            _postagemRepository = postagemRepository;
        }

        public PublicarPostagemCommandHandler(IUserInformation user,
                                              ILogger<PublicarPostagemCommandHandler> logger,
                                              IPostagemRepository postagemRepository)
            : base(user, logger)
        {
            _postagemRepository = postagemRepository;
        }

        public async Task<PublicarPostagemCommandResult> Handle(PublicarPostagemCommand request, CancellationToken cancellationToken)
        {
            Postagem postagem = new Postagem(Guid.NewGuid(),
                                             new Cabecalho(request.Titulo, request.SubTitulo),
                                             request.ConteudoPostagem);

            _postagemRepository.PublicarPostagem(postagem);
            await _postagemRepository.SaveChangesAsync();

            return await Task.FromResult(new PublicarPostagemCommandResult());
        }
    }

}
