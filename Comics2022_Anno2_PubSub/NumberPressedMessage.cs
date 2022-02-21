namespace Comics2022_Anno2_PubSub
{
    public class NumberPressedMessage : IMessage
    {
        public int Number { get; }

        public NumberPressedMessage(int number)
        {
            Number = number;
        }
    }
}