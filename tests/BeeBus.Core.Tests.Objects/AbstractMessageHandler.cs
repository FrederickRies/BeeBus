using System.Threading;
using System.Threading.Tasks;

namespace BeeBus.Core
{
    public abstract class AbstractMessageHandler : IMessageHandler<AbstractMessage>
    {
        public Task HandleAsync(AbstractMessage message, CancellationToken cancellationToken)
        {
            message.Handled = true;
            return Task.CompletedTask;
        }
    }
}
