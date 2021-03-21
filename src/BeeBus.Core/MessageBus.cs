using System;
using System.Threading;
using System.Threading.Tasks;

namespace BeeBus
{
    
    public class MessageBus : IMessageBus
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Obtain an instance of the message bus.
        /// </summary>
        /// <param name="serviceProvider"></param>
        public MessageBus(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task SendAsync<TMessage>(TMessage message, CancellationToken cancellation) where TMessage : IMessage
        {
            var handler = GetHandler<IMessageHandler<TMessage>>();
            if (handler == null)
            {
                throw new NotSupportedException();
            }
            await handler.HandleAsync(message, cancellation);
        }

        public async Task<TResponse> SendAsync<TMessage, TResponse>(TMessage message, CancellationToken cancellation) where TMessage : IMessage<TResponse>
        {
            var handler = GetHandler<IMessageHandler<TMessage, TResponse>>();
            if (handler == null)
            {
                throw new NotSupportedException();
            }
            return await handler.HandleAsync(message, cancellation);
        }

        private T GetHandler<T>()
        {
            return (T)_serviceProvider.GetService(typeof(T));
        }
    }
}
