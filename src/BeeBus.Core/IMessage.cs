namespace BeeBus
{
    /// <summary>
    /// Represent a abstract message.
    /// </summary>
    public interface IMessage
    {
    }

    /// <summary>
    /// Represent a abstract message associated with a awaited response of <typeparamref name="TResponse"/>.
    /// </summary>
    /// <typeparam name="TResponse">Response type awaited</typeparam>
    public interface IMessage<out TResponse> : IMessage
    {
    }
}