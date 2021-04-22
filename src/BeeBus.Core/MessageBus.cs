using BeeBus.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BeeBus
{
    /// <summary>
    /// Message bus responsible for the execution of the handler dedicated to a message.
    /// </summary>
    public class MessageBus : IMessageBus
    {
        private const string HandlerNotFound = "No handler was found for the message \"{0}\".";
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Obtain an instance of the message bus.
        /// </summary>
        /// <param name="serviceProvider"></param>
        public MessageBus(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <inheritdoc/>
        public async Task SendAsync<TMessage>(TMessage message, CancellationToken cancellationToken) where TMessage : IMessage
        {
            var handler = GetHandler<IMessageHandler<TMessage>>();
            if (handler == null)
            {
                throw new InvalidOperationException(string.Format(HandlerNotFound, typeof(TMessage)));
            }
            HandlerDelegate<TMessage> handlerDelegate = handler.HandleAsync;
            await handlerDelegate.Invoke(message, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<TResponse> SendAsync<TMessage, TResponse>(TMessage message, CancellationToken cancellationToken) where TMessage : IMessage<TResponse>
        {
            var handler = GetHandler<IMessageHandler<TMessage, TResponse>>();
            if (handler == null)
            {
                throw new InvalidOperationException(string.Format(HandlerNotFound, typeof(TMessage)));
            }
            HandlerDelegate<TMessage, TResponse> handlerDelegate = handler.HandleAsync;
            await handlerDelegate.Invoke(message, cancellationToken);
            return await handlerDelegate.Invoke(message, cancellationToken);
        }

        /// <summary>
        /// Retrieve the handler associated to the message.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private T GetHandler<T>()
        {
            return (T)_serviceProvider.GetService(typeof(T));
        }
    }
}
