using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Domain.Core.Authentication;
using OmegaFY.Blog.Domain.Core.Queries;

namespace OmegaFY.Blog.Application.Queries.Base
{

    public abstract class QueryHandlerBase<THandler> : IQueryHandler
    {

        protected readonly IUserInformation _user;

        protected readonly ILogger<THandler> _logger;

        public QueryHandlerBase(IUserInformation user, ILogger<THandler> logger)
        {
            _user = user;
            _logger = logger;
        }

    }

}
