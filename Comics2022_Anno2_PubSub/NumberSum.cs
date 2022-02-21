using System;

namespace Comics2022_Anno2_PubSub
{
    public class NumberSum : ISubscriber
    {
        private int _sum = 0;
        
        public void OnPublish(MessageType messageType, IMessage message)
        {
            if (messageType != MessageType.NumberPressed) return;

            NumberPressedMessage numberPressedMessage = (NumberPressedMessage)message;
            _sum += numberPressedMessage.Number;
            
            Console.WriteLine("Sum: " + _sum);
        }
    }
}