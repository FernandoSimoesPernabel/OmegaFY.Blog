using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Domain.Core.Authentication;
using OmegaFY.Blog.Domain.Core.Commands;
using OmegaFY.Blog.Domain.Core.Services;

namespace OmegaFY.Blog.Application.Commands.Base
{

    public abstract class CommandHandlerBase<THandler> : ICommandHandler
    {

        protected readonly IUserInformation _user;

        protected readonly ILogger<THandler> _logger;

        protected readonly IMapperServices _mapper;

        public CommandHandlerBase(IUserInformation user,
                                  ILogger<THandler> logger,
                                  IMapperServices mapper)
        {
            _user = user;
            _logger = logger;
            _mapper = mapper;
        }

    }

}
