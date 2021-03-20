using System.Threading;
using System.Threading.Tasks;

namespace BeeBus
{
    
    public interface IMessageHandler
    {
        Task HandleAsync<TMessage>(TMessage command, CancellationToken cancellation) where TMessage : IMessage;

        Task<TMessageResponse> HandleAsync<TMessage, TMessageResponse>(TMessage command, CancellationToken cancellation) where TMessage : IMessage<TMessageResponse>;
    }
}
