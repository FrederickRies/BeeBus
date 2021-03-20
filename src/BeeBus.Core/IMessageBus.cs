using System.Threading;
using System.Threading.Tasks;

namespace BeeBus
{
    
    public interface IMessageBus
    {
        Task SendAsync<TMessage>(TMessage command, CancellationToken cancellation) where TMessage : IMessage;

        Task<TMessageResponse> SendAsync<TMessage, TMessageResponse>(TMessage command, CancellationToken cancellation) where TMessage : IMessage<TMessageResponse>;
    }
}
