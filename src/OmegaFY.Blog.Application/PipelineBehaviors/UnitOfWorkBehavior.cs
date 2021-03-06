﻿using MediatR;
using OmegaFY.Blog.Domain.Core.Commands;
using OmegaFY.Blog.Domain.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Application.PipelineBehaviors
{

    public class UnitOfWorkBehavior<TRequest, TResult> : IPipelineBehavior<TRequest, TResult>
    {

        private readonly IUnitOfWork _unitOfWork;

        public UnitOfWorkBehavior(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<TResult> Handle(TRequest request,
                                          CancellationToken cancellationToken,
                                          RequestHandlerDelegate<TResult> next)
        {
            TResult response = await next();

            if (request is ICommand)
                await _unitOfWork.SaveChangesAsync();

            return response;
        }

    }

}
