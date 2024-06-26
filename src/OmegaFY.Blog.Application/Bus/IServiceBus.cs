﻿using OmegaFY.Blog.Application.Request;
using OmegaFY.Blog.Application.Result;
using OmegaFY.Blog.Domain.Events;

namespace OmegaFY.Blog.Application.Bus;

public interface IServiceBus
{
    public Task<TResult> SendMessageAsync<TRequest, TResult>(TRequest request, CancellationToken cancellationToken) where TRequest : IRequest where TResult : IResult;

    public Task PublishEventAsync<TDomainEvent>(TDomainEvent domainEvent) where TDomainEvent : IDomainEvent;
}