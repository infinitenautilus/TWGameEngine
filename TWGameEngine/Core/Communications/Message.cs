using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWGameEngine.Core.Communications
{
    public class Message
    {
        public IMessageReceiver Receiver { get; set; }
        
        public string Content { get; set; }
        
        public static DateTime MessageTimeStamp { get;  private set; }

        //Could add other properties to the message here

        public Message(IMessageReceiver receiver, string message)
        {
            Receiver = receiver;
            Content = message;
            MessageTimeStamp = DateTime.Now;
        }
    }
}
