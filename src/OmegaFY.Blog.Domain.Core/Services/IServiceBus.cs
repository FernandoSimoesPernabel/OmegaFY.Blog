using OmegaFY.Blog.Domain.Core.Events;
using OmegaFY.Blog.Domain.Core.Requests;
using OmegaFY.Blog.Domain.Core.Results;
using System.Threading;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Domain.Core.Services
{

    public interface IServiceBus
    {

        public Task<TResult> SendMessageAsync<TRequest, TResult>(TRequest command, CancellationToken cancellationToken) where TRequest : IRequestInput where TResult : IResult;

        public Task PublishEventAsync<TDomainEvent>(TDomainEvent domainEvent) where TDomainEvent : IDomainEvent;

    }

}
