using System.Threading;
using System.Threading.Tasks;

namespace BeeBus.Core.Dummies
{
    public class MessageWithResponseHandler : IMessageHandler<MessageWithResponse, string>
    {

        public Task<string> HandleAsync(MessageWithResponse message, CancellationToken cancellation)
        {
            message.Handled = true;
            return Task.FromResult("OK");
        }
    }
}
