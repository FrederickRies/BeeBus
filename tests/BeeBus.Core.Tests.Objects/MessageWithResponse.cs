
namespace BeeBus.Core
{
    public class MessageWithResponse : IMessage<string>
    {
        public bool Handled { get; set; }

        public MessageWithResponse()
        {
            Handled = false;
        }
    }
}
