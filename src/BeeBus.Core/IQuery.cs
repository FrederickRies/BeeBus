namespace BeeBus
{
    /// <summary>
    /// Represent a query for the CQS pattern representation.
    /// </summary>
    /// <typeparam name="TResponse">The type of response expected by the request.</typeparam>
    public interface IQuery<out TResponse> : IMessage<TResponse>
    {
    }
}
