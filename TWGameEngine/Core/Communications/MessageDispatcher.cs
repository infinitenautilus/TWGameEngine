using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWGameEngine.Core.Communications
{
    public class MessageDispatcher
    {
        private readonly Queue<Message> messageQueue = new Queue<Message>();
        private readonly Dictionary<Type, List<IMessageReceiver>> subscribers = new();

        public void Subscribe<T>(IMessageReceiver receiver) where T : IMessageReceiver
        {
            if(!subscribers.ContainsKey(typeof(T)))
            {
                subscribers[typeof(T)] = new List<IMessageReceiver>();
            }

            subscribers[typeof(T)].Add(receiver);
        }

        public void Unsubscribe<T>(IMessageReceiver receiver) where T : IMessageReceiver
        {
            if(subscribers.ContainsKey(typeof(T)))
            {
                subscribers[typeof(T)].Remove(receiver);
            }
        }

        public void SendMessage<T>(Message message) where T : IMessageReceiver
        {
            if(subscribers.TryGetValue(typeof(T), out var receiverList))
            {
                foreach(var receiver in receiverList)
                {
                    receiver.ReceiveMessage(message.Content);
                }
            }
            else
            {
                Console.WriteLine("Error in the MessageDispatcher, no subscribers were found!");
            }
        }
    }
}
