namespace BeeBus.Core.Dummies
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
