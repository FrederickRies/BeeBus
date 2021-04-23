namespace BeeBus.Core
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
