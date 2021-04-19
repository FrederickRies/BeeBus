namespace BeeBus.Core.Dummies
{
    public class AbstractMessage : IMessage
    {
        public bool Handled { get; set; }

        public AbstractMessage()
        {
            Handled = false;
        }
    }
}
