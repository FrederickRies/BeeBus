namespace BeeBus.Core
{
    public class BasicMessage : IMessage
    {
        public bool Handled { get; set; }

        public BasicMessage()
        {
            Handled = false;
        }
    }
}
