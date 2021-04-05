using System.Threading;
using System.Threading.Tasks;

namespace BeeBus
{
    /// <summary>
    /// Simple handler for a basic message without response.
    /// </summary>
    /// <typeparam name="TMessage">The type of the message to handle.</typeparam>
    public interface IMessageHandler<TMessage> : IHandler<TMessage> where TMessage : IMessage
    {
        /// <summary>
        /// Handles the message.
        /// </summary>
        /// <param name="message">The message to handle.</param>
        /// <param name="cancellation">The token to monitor for cancellation requests.</param>
        /// <returns></returns>
        Task HandleAsync(TMessage message, CancellationToken cancellation);
    }

    /// <summary>
    /// Handler dedicated to a message associated with a spectific response.
    /// </summary>
    /// <typeparam name="TMessage">The type of the message to handle.</typeparam>
    /// <typeparam name="TResponse">The type of the response awaited.</typeparam>
    public interface IMessageHandler<TMessage, TResponse> : IHandler<TMessage> where TMessage : IMessage<TResponse>
    {
        /// <summary>
        /// Handles the message and return a response.
        /// </summary>
        /// <param name="message">The message to handle.</param>
        /// <param name="cancellation">The token to monitor for cancellation requests.</param>
        /// <returns></returns>
        Task<TResponse> HandleAsync(TMessage message, CancellationToken cancellation);
    }
}
