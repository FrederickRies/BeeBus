using System.Threading;
using System.Threading.Tasks;

namespace BeeBus.Core.Dummies
{
    public abstract class AbstractMessageHandler : IMessageHandler<AbstractMessage>
    {
        public Task HandleAsync(AbstractMessage message, CancellationToken cancellation)
        {
            message.Handled = true;
            return Task.CompletedTask;
        }
    }
}
