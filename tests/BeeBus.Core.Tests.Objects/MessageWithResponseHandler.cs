using System.Threading;
using System.Threading.Tasks;

namespace BeeBus.Core
{
    public class MessageWithResponseHandler : IMessageHandler<MessageWithResponse, string>
    {
        public Task<string> HandleAsync(MessageWithResponse message, CancellationToken cancellationToken)
        {
            message.Handled = true;
            return Task.FromResult("OK");
        }
    }
}
