namespace BeeBus
{
    /// <summary>
    /// Represent a command for the CQS pattern representation.
    /// </summary>
    public interface ICommand : IMessage
    {
    }

    /// <summary>
    /// Represent a command for the CQS pattern representation.
    /// </summary>
    /// <typeparam name="TResponse">The type of response expected by the command.</typeparam>
    public interface ICommand<out TResponse> : IMessage<TResponse>
    {
    }
}
