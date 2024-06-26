﻿using MediatR;
using OmegaFY.Blog.Application.Result;
using OmegaFY.Blog.Domain.Events;

namespace OmegaFY.Blog.Application.Bus;

internal class MediatorServiceBus : IServiceBus
{
    private readonly IMediator _mediator;

    public MediatorServiceBus(IMediator mediator) => _mediator = mediator;

    public async Task PublishEventAsync<TDomainEvent>(TDomainEvent domainEvent) where TDomainEvent : IDomainEvent
        => await _mediator.Publish(domainEvent);

    public async Task<TResult> SendMessageAsync<TRequest, TResult>(TRequest request, CancellationToken cancellationToken)
        where TRequest : Request.IRequest
        where TResult : IResult
        => (TResult)await _mediator.Send(request, cancellationToken);
}
