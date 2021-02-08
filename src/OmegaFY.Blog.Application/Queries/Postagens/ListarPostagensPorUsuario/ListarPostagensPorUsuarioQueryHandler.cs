using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Application.Queries.Base;
using OmegaFY.Blog.Application.Queries.Interfaces;
using OmegaFY.Blog.Domain.Core.Authentication;
using System.Threading;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Application.Queries.Postagens.ListarPostagensPorUsuario
{

    public class ListarPostagensPorUsuarioQueryHandler : QueryHandlerMediatRBase<ListarPostagensPorUsuarioQueryHandler, ListarPostagensPorUsuarioQuery, ListarPostagensPorUsuarioQueryResult>
    {

        private readonly IPostagemQuery _postagemQuery;

        public ListarPostagensPorUsuarioQueryHandler(IUserInformation user,
                                                     ILogger<ListarPostagensPorUsuarioQueryHandler> logger,
                                                     IPostagemQuery postagemQuery) : base(user, logger)
        {
            _postagemQuery = postagemQuery;
        }

        public override async Task<ListarPostagensPorUsuarioQueryResult> Handle(ListarPostagensPorUsuarioQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _postagemQuery.ListarPostagensPorUsuarioAsync(request));
        }

    }

}
