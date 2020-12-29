using MediatR;
using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Domain.Core.Authentication;
using OmegaFY.Blog.Domain.Core.Repositories;
using OmegaFY.Blog.Domain.Core.Services;
using System.Threading;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Application.Commands.Base
{

    public abstract class CommandHandlerMediatRBase<THandler, TCommand, TResult> 
        : CommandHandlerBase<THandler>, IRequestHandler<TCommand, TResult> where TCommand : IRequest<TResult>
    {

        public CommandHandlerMediatRBase(IUserInformation user, 
                                         ILogger<THandler> logger, 
                                         IUnitOfWork unitOfWork, 
                                         IMapperServices mapper)
            : base(user, logger, unitOfWork, mapper) { }

        public abstract Task<TResult> Handle(TCommand request, CancellationToken cancellationToken);

    }

}
