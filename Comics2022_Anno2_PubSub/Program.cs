using System;

namespace Comics2022_Anno2_PubSub
{
    class Program
    {
        static void Main(string[] args)
        {
            Broker.Subscribe(MessageType.NumberPressed, new LuckyNumber());
            Broker.Subscribe(MessageType.NumberPressed, new NumberSum());
            
            while (true)
            {
                Console.WriteLine("Digita un numero: ");
                var keyInfo = Console.ReadKey(true);

                if (keyInfo.KeyChar >= '0' && keyInfo.KeyChar <= '9')
                {
                    // L'utente ha premuto un numero
                    // Dobbiamo inviare il messaggio al Broker
                    Broker.Publish(MessageType.NumberPressed, 
                        new NumberPressedMessage(keyInfo.KeyChar - '0'));
                }
                else if (keyInfo.Key == ConsoleKey.Q)
                {
                    break;
                }
            }
        }
    }
}