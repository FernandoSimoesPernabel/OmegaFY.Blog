using MediatR;
using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Domain.Core.Authentication;
using System.Threading;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Application.Queries.Base
{

    public abstract class QueryHandlerMediatRBase<THandler, TCommand, TResult>
        : QueryHandlerBase<THandler>, IRequestHandler<TCommand, TResult> where TCommand : IRequest<TResult>
    {

        public QueryHandlerMediatRBase(IUserInformation user, ILogger<THandler> logger) : base(user, logger) { }

        public abstract Task<TResult> Handle(TCommand request, CancellationToken cancellationToken);

    }

}
