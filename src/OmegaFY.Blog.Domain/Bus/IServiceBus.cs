using OmegaFY.Blog.Domain.Events;
using OmegaFY.Blog.Domain.Request;
using OmegaFY.Blog.Domain.Result;

namespace OmegaFY.Blog.Domain.Bus;

public interface IServiceBus
{

    public Task<TResult> SendMessageAsync<TRequest, TResult>(TRequest request, CancellationToken cancellationToken) where TRequest : IRequest where TResult : IResult;

    public Task PublishEventAsync<TDomainEvent>(TDomainEvent domainEvent) where TDomainEvent : IDomainEvent;

}
