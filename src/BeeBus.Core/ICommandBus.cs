using System.Threading;
using System.Threading.Tasks;

namespace BeeBus
{
    
    public interface ICommandBus
    {
        Task SendAsync<TCommand>(TCommand command, CancellationToken cancellation) where TCommand : ICommand;

        Task<TCommandResponse> SendAsync<TCommand, TCommandResponse>(TCommand command, CancellationToken cancellation) where TCommand : ICommand<TCommandResponse>;
    }
}
