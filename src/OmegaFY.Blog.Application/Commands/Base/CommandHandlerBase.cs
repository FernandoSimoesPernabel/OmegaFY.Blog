using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Domain.Core.Authentication;
using OmegaFY.Blog.Domain.Core.Commands;

namespace OmegaFY.Blog.Application.Commands.Base
{

    public abstract class CommandHandlerBase<THandler> : ICommandHandler
    {

        protected readonly IUserInformation _user;

        protected readonly ILogger<THandler> _logger;

        public CommandHandlerBase(IUserInformation user, ILogger<THandler> logger)
        {
            _user = user;
            _logger = logger;
        }

    }

}
