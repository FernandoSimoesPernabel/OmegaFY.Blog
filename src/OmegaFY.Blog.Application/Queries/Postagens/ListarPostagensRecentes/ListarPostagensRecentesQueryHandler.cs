using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Application.Queries.Interfaces;
using OmegaFY.Blog.Common.Constantes;
using OmegaFY.Blog.Common.Extensions;
using OmegaFY.Blog.Domain.Core.Authentication;
using OmegaFY.Blog.Domain.Core.Services;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Application.Queries.Postagens.ListarPostagensRecentes
{

    public class ListarPostagensRecentesQueryHandler : QueryHandlerMediatRBase<ListarPostagensRecentesQueryHandler, ListarPostagensRecentesQuery, ListarPostagensRecentesQueryResult>
    {

        private readonly IPostagemQuery _postagemQuery;

        private readonly ICacheServices _cacheServices;

        public ListarPostagensRecentesQueryHandler(IUserInformation user,
                                                   ILogger<ListarPostagensRecentesQueryHandler> logger,
                                                   IPostagemQuery postagemQuery,
                                                   ICacheServices cacheServices)
            : base(user, logger)
        {
            _postagemQuery = postagemQuery;
            _cacheServices = cacheServices;
        }

        public async override Task<ListarPostagensRecentesQueryResult> Handle(ListarPostagensRecentesQuery request, CancellationToken cancellationToken)
        {
            ListarPostagensRecentesQueryResult result = null;

            string cachedResult = await _cacheServices.GetStringAsync(CachedKeysConstantes.KEY_LISTAR_POSTAGENS_RECENTES, cancellationToken);

            if (cachedResult is not null)
                result = JsonSerializer.Deserialize<ListarPostagensRecentesQueryResult>(cachedResult);

            if (VerificarSeCacheRecuperadoEstaInvalido(result, request.QuantidadeDePostagens))
                result = await _postagemQuery.ListarPostagensRecentesAsync(request);

            if (VerificarSeDeveGravarResultadoNoCache(result, cachedResult))
                await _cacheServices.SetStringAsync(CachedKeysConstantes.KEY_LISTAR_POSTAGENS_RECENTES, result.ToJson(), cancellationToken);

            return result;
        }

        private bool VerificarSeCacheRecuperadoEstaInvalido(ListarPostagensRecentesQueryResult result, int quantidadeDePostagensSolicitadas)
        {
            int quantidadeDePostagensNoCache = result?.PostagensRecentes?.Count() ?? 0;
            return quantidadeDePostagensNoCache == 0 || quantidadeDePostagensNoCache != quantidadeDePostagensSolicitadas;
        }

        private bool VerificarSeDeveGravarResultadoNoCache(ListarPostagensRecentesQueryResult result, string conteudoNoCacheAtual)
            => result?.PostagensRecentes?.Count() > 0 && conteudoNoCacheAtual is null;

    }

}
