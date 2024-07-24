﻿using MediatR;
using OmegaFY.Blog.Application.Result;
using OmegaFY.Blog.Domain.Events;

namespace OmegaFY.Blog.Application.Bus;

internal sealed class MediatorServiceBus : IServiceBus
{
    private readonly IMediator _mediator;

    public MediatorServiceBus(IMediator mediator) => _mediator = mediator;

    public Task PublishEventAsync<TDomainEvent>(TDomainEvent domainEvent) where TDomainEvent : IDomainEvent
        => _mediator.Publish(domainEvent);

    public async Task<TResult> SendMessageAsync<TRequest, TResult>(TRequest request, CancellationToken cancellationToken)
        where TRequest : Request.IRequest
        where TResult : IResult
        => (TResult)await _mediator.Send(request, cancellationToken);
}
