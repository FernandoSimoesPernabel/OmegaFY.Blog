using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Commands.Base;
using OmegaFY.Blog.Domain.Core.Authentication;
using OmegaFY.Blog.Domain.Core.Repositories;
using OmegaFY.Blog.Domain.Core.Services;
using OmegaFY.Blog.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Application.Commands.Postagens.AvaliarPostagem
{

    public class AvaliarPostagemCommandHandler : CommandHandlerMediatRBase<AvaliarPostagemCommandHandler, AvaliarPostagemCommand, AvaliarPostagemCommandResult>
    {

        private readonly IPostagemRepository _postagemRepository;

        public AvaliarPostagemCommandHandler(IUserInformation user,
                                             ILogger<AvaliarPostagemCommandHandler> logger,
                                             IUnitOfWork unitOfWork,
                                             IMapperServices mapper,
                                             IPostagemRepository postagemRepository)
            : base(user, logger, mapper)
        {
            _postagemRepository = postagemRepository;
        }

        public async override Task<AvaliarPostagemCommandResult> Handle(AvaliarPostagemCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }

}
