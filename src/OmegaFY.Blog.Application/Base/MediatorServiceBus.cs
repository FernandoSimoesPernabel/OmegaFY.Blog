using MediatR;
using OmegaFY.Blog.Domain.Core.Events;
using OmegaFY.Blog.Domain.Core.Requests;
using OmegaFY.Blog.Domain.Core.Results;
using OmegaFY.Blog.Domain.Core.Services;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Application.Base
{

    public class MediatorServiceBus : IServiceBus
    {

        private readonly IMediator _mediator;

        public MediatorServiceBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<TResult> SendMessageAsync<TRequest, TResult>(TRequest command) where TRequest : IRequestInput
                                                                                         where TResult : IResult
            => (TResult)await _mediator.Send(command);

        public async Task PublishEventAsync<TDomainEvent>(TDomainEvent domainEvent) where TDomainEvent : IDomainEvent
            => await _mediator.Publish(domainEvent);

    }

}
