namespace BeeBus.Core.Dummies
{
    public class InterfaceMessage : IMessage
    {
        public bool Handled { get; set; }

        public InterfaceMessage()
        {
            Handled = false;
        }
    }
}
