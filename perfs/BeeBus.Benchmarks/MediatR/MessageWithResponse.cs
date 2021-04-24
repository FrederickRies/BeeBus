
using MediatR;

namespace Benchmarks.MediatR
{
    public class MessageWithResponse : IRequest<string>
    {
        public bool Handled { get; set; }

        public MessageWithResponse()
        {
            Handled = false;
        }
    }
}
