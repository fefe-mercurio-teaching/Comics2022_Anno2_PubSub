using System;
using System.Collections.Generic;

namespace Comics2022_Anno2_PubSub
{
    public static class Broker
    {
        private static Dictionary<MessageType, List<ISubscriber>> _allSubscribers = new Dictionary<MessageType, List<ISubscriber>>();

        // Registra un subscriber all'interno di una lista
        public static void Subscribe(MessageType messageType, ISubscriber subscriber)
        {
            if (_allSubscribers.ContainsKey(messageType))
            {
                _allSubscribers[messageType].Add(subscriber);
            }
            else
            {
                List<ISubscriber> subscribers = new List<ISubscriber> { subscriber };

                _allSubscribers.Add(messageType, subscribers);
            }
        }

        // Invia il messaggio
        public static void Publish(MessageType messageType, IMessage message)
        {
            if (!_allSubscribers.ContainsKey(messageType)) return;

            foreach (ISubscriber subscriber in _allSubscribers[messageType])
            {
                // Diciamo al Subscriber che è stato pubblicato il messaggio messageType
                subscriber.OnPublish(messageType, message);
            }
        }
    }
}