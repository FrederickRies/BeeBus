using MediatR;

namespace Benchmarks.MediatR
{
    public class BasicMessage : IRequest
    {
        public bool Handled { get; set; }

        public BasicMessage()
        {
            Handled = false;
        }
    }
}
