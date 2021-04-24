using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Benchmarks.MediatR
{
    public class MessageWithResponseHandler : IRequestHandler<MessageWithResponse, string>
    {
        public Task<string> Handle(MessageWithResponse request, CancellationToken cancellationToken)
        {
            request.Handled = true;
            return Task.FromResult("OK");
        }
    }
}
