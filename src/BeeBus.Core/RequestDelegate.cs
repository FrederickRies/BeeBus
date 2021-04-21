using System.Threading;
using System.Threading.Tasks;

namespace BeeBus.Core
{
    /// <summary>
    /// A function that can process a message
    /// </summary>
    /// <typeparam name="TMessage">The type of the message to handle.</typeparam>
    /// <param name="message">The message to handle.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns></returns>
    public delegate Task RequestDelegate<in TMessage>(TMessage message, CancellationToken cancellationToken);

    /// <summary>
    /// A function that can process a message and produce a response
    /// </summary>
    /// <typeparam name="TMessage">The type of the message to handle.</typeparam>
    /// <typeparam name="TResponse">The type of the response awaited.</typeparam>
    /// <param name="message">The message to handle.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns></returns
    public delegate Task<TResponse> RequestDelegate<in TMessage, TResponse>(TMessage message, CancellationToken cancellationToken);
}
