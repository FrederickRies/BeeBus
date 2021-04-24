using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Benchmarks.MediatR
{
    public class BasicMessageHandler : IRequestHandler<BasicMessage>
    {
        public Task<Unit> Handle(BasicMessage request, CancellationToken cancellationToken)
        {
            request.Handled = true;
            return Unit.Task;
        }
    }
}
