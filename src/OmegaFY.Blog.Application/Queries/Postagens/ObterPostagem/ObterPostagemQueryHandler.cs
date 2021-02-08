using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Application.Queries.Interfaces;
using OmegaFY.Blog.Common.Constantes;
using OmegaFY.Blog.Common.Extensions;
using OmegaFY.Blog.Domain.Core.Authentication;
using OmegaFY.Blog.Domain.Core.Services;
using OmegaFY.Blog.Domain.Exceptions;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Application.Queries.Postagens.ObterPostagem
{

    public class ObterPostagemQueryHandler : QueryHandlerMediatRBase<ObterPostagemQueryHandler, ObterPostagemQuery, ObterPostagemQueryResult>
    {

        private readonly IPostagemQuery _postagemQuery;

        private readonly ICacheServices _cacheServices;

        public ObterPostagemQueryHandler(IUserInformation user,
                                         ILogger<ObterPostagemQueryHandler> logger,
                                         IPostagemQuery postagemQuery,
                                         ICacheServices cacheServices)
            : base(user, logger)
        {
            _postagemQuery = postagemQuery;
            _cacheServices = cacheServices;
        }

        public override async Task<ObterPostagemQueryResult> Handle(ObterPostagemQuery request, CancellationToken cancellationToken)
        {
            ObterPostagemQueryResult result = null;

            string cachedResult = await _cacheServices.GetStringAsync(FormatarKeyParaCache(request.Id), cancellationToken);

            if (cachedResult is not null)
                result = JsonSerializer.Deserialize<ObterPostagemQueryResult>(cachedResult);
            else
            {
                result = await _postagemQuery.ObterPostagemAsync(request);

                if (result is null)
                    throw new NotFoundException("Não foi possível encontrar a postagem informada em nossa base de dados.");

                await _cacheServices.SetStringAsync(FormatarKeyParaCache(request.Id), result.ToJson(), cancellationToken);
            }

            return await Task.FromResult(result);
        }

        private string FormatarKeyParaCache(Guid id) => string.Format(CachedKeysConstantes.KEY_OBTER_POSTAGEM_ID, id);

    }

}
