using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Application.Queries.Interfaces;
using OmegaFY.Blog.Domain.Core.Authentication;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Application.Queries.Postagens.ListarPostagensRecentes
{

    public class ListarPostagensRecentesQueryHandler : QueryHandlerMediatRBase<ListarPostagensRecentesQueryHandler, ListarPostagensRecentesQuery, ListarPostagensRecentesQueryResult>
    {

        private readonly IPostagemQuery _postagemQuery;

        public ListarPostagensRecentesQueryHandler(IUserInformation user,
                                                   ILogger<ListarPostagensRecentesQueryHandler> logger,
                                                   IPostagemQuery postagemQuery)
            : base(user, logger)
        {
            _postagemQuery = postagemQuery;
        }

        public async override Task<ListarPostagensRecentesQueryResult> Handle(ListarPostagensRecentesQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _postagemQuery.ListarPostagensRecentesAsync(request));
        }

    }

}
