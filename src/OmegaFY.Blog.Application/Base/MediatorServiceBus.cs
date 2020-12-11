using MediatR;
using OmegaFY.Blog.Domain.Core.Events;
using OmegaFY.Blog.Domain.Core.Requests;
using OmegaFY.Blog.Domain.Core.Results;
using OmegaFY.Blog.Domain.Core.Services;
using System.Threading;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Application.Base
{

    /// <summary>
    /// Implementação do IServiceBus utilizando o pacote MediatR.
    /// </summary>
    internal class MediatorServiceBus : IServiceBus
    {

        /// <summary>
        /// Instancia da implementação do IMediator injetado em memoria pelo MediatR.
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// Construtor da classe MediatorServiceBus, recebe um IMediator por injeção.
        /// </summary>
        /// <param name="mediator">Instancia do IMediator injetado.</param>
        public MediatorServiceBus(IMediator mediator) => _mediator = mediator;

        /// <inheritdoc/>
        public async Task<TResult> SendMessageAsync<TRequest, TResult>(TRequest command, CancellationToken cancellationToken) 
            where TRequest : IRequestInput
            where TResult : IResult
            => (TResult)await _mediator.Send(command, cancellationToken);

        /// <inheritdoc/>
        public async Task PublishEventAsync<TDomainEvent>(TDomainEvent domainEvent) where TDomainEvent : IDomainEvent
            => await _mediator.Publish(domainEvent);

    }

}
