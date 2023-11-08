using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWGameEngine.Core.Communications;

namespace TWGameEngine.Core.Library.GameObjects
{
    public class Actor : GameObject, IMessageReceiver
    {
        public Actor(string shortName) : base(shortName) 
        {
            Description = "This is the actor class itself and no description has been set";
        }

        public void ReceiveMessage(string message)
        {
            Console.WriteLine(message);
        }

    }
}
