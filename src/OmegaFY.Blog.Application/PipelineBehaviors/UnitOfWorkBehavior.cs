using MediatR;
using OmegaFY.Blog.Application.Base;
using OmegaFY.Blog.Domain.Commands;
using OmegaFY.Blog.Domain.Repositories;

namespace OmegaFY.Blog.Application.PipelineBehaviors;

public class UnitOfWorkBehavior<TCommand, TResult> : IPipelineBehavior<TCommand, TResult> where TCommand : IRequest<TResult>, ICommand where TResult : GenericResult
{
    private readonly IUnitOfWork _unitOfWork;

    public UnitOfWorkBehavior(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<TResult> Handle(TCommand request,
                                      CancellationToken cancellationToken,
                                      RequestHandlerDelegate<TResult> next)
    {
        TResult response = await next();

        await _unitOfWork.SaveChangesAsync();

        return response;
    }
}
