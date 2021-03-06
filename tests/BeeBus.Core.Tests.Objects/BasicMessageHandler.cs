using System.Threading;
using System.Threading.Tasks;

namespace BeeBus.Core
{
    public class BasicMessageHandler : IMessageHandler<BasicMessage>
    {
        public Task HandleAsync(BasicMessage message, CancellationToken cancellationToken)
        {
            message.Handled = true;
            return Task.CompletedTask;
        }
    }
}
