using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Application.Queries.Interfaces;
using OmegaFY.Blog.Domain.Core.Authentication;
using OmegaFY.Blog.Domain.Exceptions;
using System.Threading;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Application.Queries.Postagens.ObterPostagem
{

    public class ObterPostagemQueryHandler : QueryHandlerMediatRBase<ObterPostagemQueryHandler, ObterPostagemQuery, ObterPostagemQueryResult>
    {

        private readonly IPostagemQuery _postagemQuery;

        public ObterPostagemQueryHandler(IUserInformation user,
                                         ILogger<ObterPostagemQueryHandler> logger,
                                         IPostagemQuery postagemQuery)
            : base(user, logger)
        {
            _postagemQuery = postagemQuery;
        }

        public override async Task<ObterPostagemQueryResult> Handle(ObterPostagemQuery request, CancellationToken cancellationToken)
        {
            ObterPostagemQueryResult result = await _postagemQuery.ObterPostagemAsync(request);

            if (result is null)
                throw new NotFoundException("Não foi possível encontrar a postagem informada em nossa base de dados.");

            return await Task.FromResult(result);
        }

    }

}
