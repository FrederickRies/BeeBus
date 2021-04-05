using System;
using System.Threading;
using System.Threading.Tasks;

namespace BeeBus
{
    /// <summary>
    /// Interface of the message bus 
    /// </summary>
    public interface IMessageBus
    {
        /// <summary>
        /// Send a message to the bus awaiting processing.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when no handler is found to handle the message.</exception>
        /// <typeparam name="TMessage">The type of the message to handle.</typeparam>
        /// <param name="message">The message to handle.</param>
        /// <param name="cancellation"></param>
        /// <returns>A <see cref="Task"/> that indiquate the completion of the handling of the message.</returns>
        Task SendAsync<TMessage>(TMessage message, CancellationToken cancellation) where TMessage : IMessage;

        /// <summary>
        /// send a message to the bus awaiting processing and the return of the associated response.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when no handler is found to handle the message.</exception>
        /// <typeparam name="TMessage">The type of the message to handle.</typeparam>
        /// <typeparam name="TMessageResponse">The type of the response awaited.</typeparam>
        /// <param name="message">The message to handle.</param>
        /// <param name="cancellation"></param>
        /// <returns>A <see cref="Task"/> that on completion returns the associated response for the message.</returns>
        Task<TMessageResponse> SendAsync<TMessage, TMessageResponse>(TMessage message, CancellationToken cancellation) where TMessage : IMessage<TMessageResponse>;
    }
}
