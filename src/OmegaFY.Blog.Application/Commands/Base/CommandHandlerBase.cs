using Microsoft.Extensions.Logging;
using OmegaFY.Blog.Domain.Core.Authentication;
using OmegaFY.Blog.Domain.Core.Commands;
using OmegaFY.Blog.Domain.Core.Repositories;
using OmegaFY.Blog.Domain.Core.Services;

namespace OmegaFY.Blog.Application.Commands.Base
{

    public abstract class CommandHandlerBase<THandler> : ICommandHandler
    {

        protected readonly IUserInformation _user;

        protected readonly ILogger<THandler> _logger;

        protected readonly IUnitOfWork _unitOfWork;

        protected readonly IMapperServices _mapper;

        public CommandHandlerBase(IUserInformation user,
                                  ILogger<THandler> logger,
                                  IUnitOfWork unitOfWork,
                                  IMapperServices mapper)
        {
            _user = user;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

    }

}
