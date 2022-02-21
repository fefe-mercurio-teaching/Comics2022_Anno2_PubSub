using System;

namespace Comics2022_Anno2_PubSub
{
    public class LuckyNumber : ISubscriber
    {
        private int _luckyNumber;
        private Random _randomGenerator;

        public LuckyNumber()
        {
            _randomGenerator = new Random();
            
            GenerateLuckyNumber();
        }

        private void GenerateLuckyNumber()
        {
            _luckyNumber = _randomGenerator.Next(10);
        }
        
        public void OnPublish(MessageType messageType, IMessage message)
        {
            if (messageType != MessageType.NumberPressed) return;

            NumberPressedMessage numberPressedMessage = (NumberPressedMessage)message;
            if (numberPressedMessage.Number == _luckyNumber)
            {
                Console.WriteLine("Lucky Number! " + _luckyNumber);
                
                GenerateLuckyNumber();
            }
        }
    }
}