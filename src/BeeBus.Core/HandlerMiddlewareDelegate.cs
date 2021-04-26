using System.Threading;
using System.Threading.Tasks;

namespace BeeBus.Core
{
    public delegate Task RequestMiddlewareDelegate<TMessage>(TMessage message, HandlerDelegate<TMessage> next, CancellationToken cancellationToken);

    public delegate Task<TResponse> RequestMiddlewareDelegate<TMessage, TResponse>(TMessage request, HandlerDelegate<TMessage, TResponse> next, CancellationToken cancellationToken);
}
