﻿using System.Threading;
using System.Threading.Tasks;

namespace BeeBus
{
    public interface IMessageHandler<TMessage> where TMessage : IMessage
    {
        Task HandleAsync(TMessage command, CancellationToken cancellation);
    }

    public interface IMessageHandler<TMessage, TResponse> where TMessage : IMessage<TResponse>
    {
        Task<TResponse> HandleAsync(TMessage command, CancellationToken cancellation);
    }
}